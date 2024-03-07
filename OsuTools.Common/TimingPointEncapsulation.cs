using OsuParsers.Beatmaps.Objects;

namespace OsuTools.Common;

public sealed class TimingPointEncapsulation(
    TimingPoint parent, List<TimingPoint> inheritedPoints)
{
    public TimingPoint Parent { get; } = parent;
    public List<TimingPoint> InheritedPoints { get; } = inheritedPoints;

    public int StartOffset => Parent.Offset;
    public int EndOffset { get; set; } = int.MaxValue;

    public int Length => EndOffset - StartOffset;

    public bool HandlesOffset(int offset)
    {
        return offset >= StartOffset
            && offset < EndOffset;
    }
}
