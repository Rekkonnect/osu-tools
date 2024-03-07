using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuTools.Common;

namespace OsuFileTools;

internal class TimingPointResnapper : ITransformer
{
    public required TimingPointResnappingOptions Options { get; init; }

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
        if (Options.PreviousBeatLength is BeatLength previousBeatLength)
        {
            // Calculate the existing snap point from the previous beat length
            // And then snap based on the number of beat divisors from the parent timing point's offset
            int beats = GetClosestSnappedDivisorBeats(offset, parent, previousBeatLength);
            var divisorLength = parent.BeatLength / Options.TimingSignatureDivisor;
            double newOffset = divisorLength * beats;
            int newIntOffset = (int)Math.Round(newOffset);
            int newTimingPointOffset = parent.Offset + newIntOffset;
            timingPoint.Offset = newTimingPointOffset;
        }
        else
        {
            int newOffset = GetClosestSnappedOffset(offset, parent);
            timingPoint.Offset = newOffset;
        }
    }

    private int GetClosestSnappedOffset(int offset, TimingPoint parentTiming)
    {
        var length = new BeatLength(parentTiming.BeatLength);
        return GetClosestSnappedOffset(offset, parentTiming, length);
    }

    private int GetClosestSnappedOffset(int offset, TimingPoint parentTiming, BeatLength beatLength)
    {
        int beats = GetClosestSnappedDivisorBeats(offset, parentTiming, beatLength);
        double beatDuration = beatLength.Length;
        double snapped = beats * beatDuration;
        int intSnapped = (int)Math.Round(snapped);
        return intSnapped;
    }
    private int GetClosestSnappedDivisorBeats(
        int offset,
        TimingPoint parentTiming,
        BeatLength beatLength)
    {
        int localOffset = offset - parentTiming.Offset;
        // We won't support this case for now
        if (localOffset < 0)
            return -1;

        double beatDuration = beatLength.Length;
        double divisorDuration = beatDuration / Options.TimingSignatureDivisor;
        double offsetBeats = localOffset / beatDuration;
        double divisorBeats = Options.TimingSignatureDivisor * offsetBeats;
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
}

public sealed class TimingPointResnappingOptions
{
    public int TimingSignatureDivisor { get; set; }
    public BeatLength? PreviousBeatLength { get; set; }
}
