using OsuParsers.Beatmaps.Objects;

namespace OsuRealDifficulty;

public readonly record struct SnappedPosition(int Index, TimeDivisor Divisor)
{
    public static SnappedPosition Invalid { get; } = new(0, TimeDivisor.Invalid);

    public int BeatIndex => Index / Divisor.Denominator;
    public int BeatDivisorIndex => Index % Divisor.Denominator;

    public BeatSnappedPosition AsBeatSnapped
    {
        get
        {
            var denominator = Divisor.Denominator;
            if (denominator is 0)
                return BeatSnappedPosition.Invalid;

            var (beat, index) = Math.DivRem(Index, denominator);
            return new(beat, index, Divisor);
        }
    }

    public int MeasureIndex(TimingPoint parentTimingPoint)
    {
        var beatsPerMeasure = (int)parentTimingPoint.TimeSignature;
        return BeatIndex / beatsPerMeasure;
    }
    public int MeasureBeatIndex(TimingPoint parentTimingPoint)
    {
        var beatsPerMeasure = (int)parentTimingPoint.TimeSignature;
        return BeatIndex % beatsPerMeasure;
    }
}
