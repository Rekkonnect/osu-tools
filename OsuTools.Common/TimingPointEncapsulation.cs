using OsuParsers.Beatmaps.Objects;

namespace OsuTools.Common;

public sealed class TimingPointEncapsulation(
    TimingPoint parent, List<TimingPoint> inheritedPoints)
{
    public TimingPoint Parent { get; } = parent;
    public List<TimingPoint> InheritedPoints { get; } = inheritedPoints;

    public double StartOffset => Parent.Offset;
    public double EndOffset { get; set; } = int.MaxValue;

    public double Length => EndOffset - StartOffset;

    public bool HandlesOffset(int offset)
    {
        return offset >= StartOffset
            && offset < EndOffset;
    }
}
