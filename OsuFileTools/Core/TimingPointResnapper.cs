using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuTools.Common;

namespace OsuFileTools.Core;

internal class TimingPointResnapper(
    TimingPointResnapper.Options options)
    : ITransformer
{
    private readonly Options _options = options;

    public Beatmap Transform(Beatmap b)
    {
        var clone = b.Clone();

        var pointList = TimingPointList.FromBeatmap(clone);
        var encapsulations = pointList.GetEncapsulations();
        foreach (var encapsulation in encapsulations.Encapsulations)
        {
            var parent = encapsulation.Parent;
            foreach (var inherited in encapsulation.InheritedPoints)
            {
                // This should suffice; the underlying values of the timing point are changed
                TransformTimingPoint(inherited, parent);
            }
        }

        return clone;
    }

    private void TransformTimingPoint(TimingPoint timingPoint, TimingPoint parent)
    {
        var offset = timingPoint.Offset;
        if (_options.PreviousBeatLength is BeatLength previousBeatLength)
        {
            // Calculate the existing snap point from the previous beat length
            // And then snap based on the number of beat divisors from the parent timing point's offset
            int beats = GetClosestSnappedDivisorBeats(offset, parent, previousBeatLength);
            var divisorLength = parent.BeatLength / _options.TimingSignatureDivisor;
            double newOffset = divisorLength * beats;
            double newTimingPointOffset = parent.Offset + newOffset;
            timingPoint.Offset = newTimingPointOffset;
        }
        else
        {
            int newOffset = GetClosestSnappedOffset(offset, parent);
            timingPoint.Offset = newOffset;
        }
    }

    private int GetClosestSnappedOffset(double offset, TimingPoint parentTiming)
    {
        var length = new BeatLength(parentTiming.BeatLength);
        return GetClosestSnappedOffset(offset, parentTiming, length);
    }

    private int GetClosestSnappedOffset(double offset, TimingPoint parentTiming, BeatLength beatLength)
    {
        int beats = GetClosestSnappedDivisorBeats(offset, parentTiming, beatLength);
        double beatDuration = beatLength.Length;
        double snapped = beats * beatDuration;
        int intSnapped = (int)Math.Round(snapped);
        return intSnapped;
    }
    private int GetClosestSnappedDivisorBeats(
        double offset,
        TimingPoint parentTiming,
        BeatLength beatLength)
    {
        double localOffset = offset - parentTiming.Offset;
        // We won't support this case for now
        if (localOffset < 0)
            return -1;

        double beatDuration = beatLength.Length;
        double divisorDuration = beatDuration / _options.TimingSignatureDivisor;
        double offsetBeats = localOffset / beatDuration;
        double divisorBeats = _options.TimingSignatureDivisor * offsetBeats;
        int prevIntDivisorBeats = (int)divisorBeats;
        int nextIntDivisorBeats = prevIntDivisorBeats + 1;
        double prevSnapped = prevIntDivisorBeats * divisorDuration;
        double nextSnapped = nextIntDivisorBeats * divisorDuration;
        int prevIntSnapped = (int)Math.Round(prevSnapped);
        int nextIntSnapped = (int)Math.Round(nextSnapped);

        double prevSnapError = Math.Abs(prevIntSnapped - localOffset);
        double nextSnapError = Math.Abs(nextIntSnapped - localOffset);
        if (prevSnapError < nextSnapError)
        {
            return prevIntDivisorBeats;
        }
        else
        {
            return nextIntDivisorBeats;
        }
    }

    public sealed class Options
    {
        public int TimingSignatureDivisor;
        public BeatLength? PreviousBeatLength;
    }
}
