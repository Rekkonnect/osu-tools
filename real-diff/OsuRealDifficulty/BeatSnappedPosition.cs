using OsuParsers.Beatmaps.Objects;

namespace OsuRealDifficulty;

public readonly record struct BeatSnappedPosition(int Beat, int Index, TimeDivisor Divisor)
{
    public static BeatSnappedPosition Invalid { get; } = new(0, 0, TimeDivisor.Invalid);

    public int GlobalIndex => Beat * Index;
    public bool IsUnsnapped => Divisor.IsInvalid;

    public SnappedPosition AsSimple => new(GlobalIndex, Divisor);

    public int MeasureIndex(TimingPoint parentTimingPoint)
    {
        var beatsPerMeasure = (int)parentTimingPoint.TimeSignature;
        return Beat / beatsPerMeasure;
    }
    public int MeasureBeatIndex(TimingPoint parentTimingPoint)
    {
        var beatsPerMeasure = (int)parentTimingPoint.TimeSignature;
        return Beat % beatsPerMeasure;
    }
}
