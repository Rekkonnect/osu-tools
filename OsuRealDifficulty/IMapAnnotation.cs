using Garyon.Extensions;
using OsuParsers.Beatmaps.Objects;
using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty;

#region Base pattern definitions

public interface IMapAnnotation
{
    public MapAnnotationType Type { get; }
}

public interface ISinglePointAnnotation : IMapAnnotation
{
    public int Offset { get; }
}

public interface ITimingPointAnnotation : ISinglePointAnnotation
{
    public TimingPoint TimingPoint { get; }

    int ISinglePointAnnotation.Offset => TimingPoint.Offset;
}

public interface IPattern : IMapAnnotation
{
    public int OffsetStart { get; }
    public int OffsetEnd { get; }

    public int TimeDistance => OffsetEnd - OffsetStart;
}

public interface ITwoNotePattern : IPattern
{
    public int FirstOffset { get; }
    public int SecondOffset { get; }

    int IPattern.OffsetStart => FirstOffset;
    int IPattern.OffsetEnd => SecondOffset;
}

public interface INotePattern : IPattern
{

}

public interface ITimingPointPattern : IPattern
{
    public IEnumerable<TimingPoint> TimingPoints { get; }

    int IPattern.OffsetStart => TimingPoints.First().Offset;
    int IPattern.OffsetEnd => TimingPoints.Last().Offset;
}

#endregion

#region Comparers

public sealed class AscendingOffsetsTypesMapAnnotationComparer : IComparer<IMapAnnotation>
{
    public static AscendingOffsetsTypesMapAnnotationComparer Instance { get; } = new();

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    public int Compare(IMapAnnotation x, IMapAnnotation y)
    {
        ArgumentNullException.ThrowIfNull(x);
        ArgumentNullException.ThrowIfNull(y);

        GetOffsetValues(x, out var xStart, out var xEnd);
        GetOffsetValues(y, out var yStart, out var yEnd);

        int comparison = xStart.CompareTo(yStart);
        if (comparison is not 0)
            return comparison;

        comparison = xEnd.CompareTo(yEnd);
        if (comparison is not 0)
            return comparison;

        comparison = x.Type.CompareTo(y.Type);
        if (comparison is not 0)
            return comparison;

        return comparison;
    }
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

    private static void GetOffsetValues(
        IMapAnnotation annotation,
        out int start,
        out int end)
    {
        switch (annotation)
        {
            case ISinglePointAnnotation single:
                start = single.Offset;
                end = start;
                break;

            case IPattern pattern:
                start = pattern.OffsetStart;
                end = pattern.OffsetEnd;
                break;

            default:
                start = 0;
                end = start;
                break;
        }
    }
}

#endregion
