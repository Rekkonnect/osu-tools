using OsuParsers.Beatmaps.Objects;

namespace OsuTools.Common;

public static class TimingPointFactory
{
    public static void CreateWithNormalization(
        BeatLength currentBeatLength,
        BeatLength normalizedBeatLength,
        out TimingPoint parent,
        out TimingPoint normalizer)
    {
        parent = new()
        {
            BeatLength = currentBeatLength.Length * 1000,
        };
        var normalizationRatio = currentBeatLength.Length / normalizedBeatLength.Length;
        normalizer = CreateSV(normalizationRatio);
    }

    public static TimingPoint CreateSV(double velocity)
    {
        var timingPoint = new TimingPoint
        {
            Inherited = true
        };
        timingPoint.SetSliderVelocity(velocity);
        return timingPoint;
    }
}
