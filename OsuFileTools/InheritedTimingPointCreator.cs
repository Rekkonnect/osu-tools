using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuTools.Common;

namespace OsuFileTools;

public sealed class InheritedTimingPointCreator : ITransformer
{
    public required InheritedTimingPointCreationOptions Options { get; init; }

    public Beatmap Transform(Beatmap b)
    {
        var clone = b.Clone();

        var pointList = TimingPointList.FromBeatmap(clone);
        var encapsulations = pointList.GetEncapsulations();
        foreach (var encapsulation in encapsulations.Encapsulations)
        {
            var parent = encapsulation.Parent;

            // Remove the current inherited point on top of the parent
            encapsulation.InheritedPoints.RemoveAll(s => s.Offset == parent.Offset);

            var inherited = CreateInherited(parent);
            encapsulation.InheritedPoints.Add(inherited);
        }

        var newTimingPoints = encapsulations.Flatten();
        clone.TimingPoints = newTimingPoints.TimingPoints;

        return clone;
    }

    private TimingPoint CreateInherited(TimingPoint parent)
    {
        var inherited = parent.Clone();
        var parentBeatLength = parent.BeatLengthNormalized();
        var parentBpm = parentBeatLength.Bpm;
        var baselineBpm = Options.BaselineBpm;
        var ratio = parentBpm / baselineBpm;

        inherited.Inherited = true;
        inherited.SetSliderVelocity(1 / ratio);
        return inherited;
    }
}

public sealed class InheritedTimingPointCreationOptions
{
    public double BaselineBpm { get; set; }
}
