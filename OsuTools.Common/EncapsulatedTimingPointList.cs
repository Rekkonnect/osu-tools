using OsuParsers.Beatmaps;

namespace OsuTools.Common;

public sealed class EncapsulatedTimingPointList
{
    public List<TimingPointEncapsulation> Encapsulations { get; } = new();

    public TimingPointEncapsulation? EncapsulationAtOffset(int offset)
    {
        return Encapsulations
            .FirstOrDefault(s => s.HandlesOffset(offset));
    }

    public static EncapsulatedTimingPointList FromBeatmap(Beatmap beatmap)
    {
        var list = TimingPointList.FromBeatmap(beatmap);
        return list.GetEncapsulations();
    }
}
