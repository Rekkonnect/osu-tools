using Garyon.Extensions;
using OsuParsers.Beatmaps.Objects;
using System.Collections.Specialized;

namespace OsuRealDifficulty.Mania;

#region Base pattern definitions

public interface IMapAnnotation
{
    public MapAnnotationType Type { get; }
}

public interface ISinglePointAnnotation : IMapAnnotation
{
    public int Offset { get; }
}

public interface IChordAnnotation : ISinglePointAnnotation
{
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

    public int Length => OffsetEnd - OffsetStart;
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

#region

public record ChordAnnotation(int Offset, int NoteCount)
    : IChordAnnotation
{
    public MapAnnotationType Type => MapAnnotationType.Chord;
}

/// <summary>
/// Represents a trill pattern, consisting of at least 3 chords.
/// Each trill instance may consist of multiple columns, as specified.
/// </summary>
/// <param name="OffsetStart">The inclusive offset that the trill starts at.</param>
/// <param name="OffsetEnd">The inclusive offset that the trill ends at.</param>
/// <param name="NoteCount">The number of notes that this trill occupies.</param>
/// <param name="Columns">
/// The columns that are present in the trill pattern.
/// This includes both the columns in the first and the second pattern that is
/// being alternatingly repeated during the trill.
/// </param>
/// <remarks>
/// Each individual instance only marks the equidistant trilling notes for some columns.
/// If other columns stop being part of the trill, multiple instances reflect the 3+-chord
/// participation of the multiple columns. Examples can be found in the tests.
/// </remarks>
public record TrillPattern(int OffsetStart, int OffsetEnd, int NoteCount, BitVector32 Columns)
    : INotePattern
{
    public int ColumnCount => Columns.Data.PopCount();

    public double NotesPerSecond => NoteCount / LengthSeconds;
    public int Length => OffsetEnd - OffsetStart;
    public double LengthSeconds => Length / 1000D;
    public double ColumnHitsPerSecond => NotesPerSecond / ColumnCount;

    public MapAnnotationType Type => MapAnnotationType.Trill;
}

/// <summary>
/// Represents a singlestream pattern, consisting of at least 3 continuous chords
/// of single notes. All chords must have a single finger press.
/// </summary>
/// <param name="OffsetStart">The inclusive offset that the singlestream starts at.</param>
/// <param name="OffsetEnd">The inclusive offset that the singlestream ends at.</param>
/// <param name="NoteCount">The number of notes that this singlestream occupies.</param>
/// <param name="ColumnCount">
/// The number of columns that are present in the singlestream pattern.
/// </param>
/// <param name="TotalColumnDistance">
/// The total column distance, as though the stream is a path across the columns
/// as time passes.
/// </param>
/// <remarks>
/// Each individual instance only marks the continuous stream of single-note chords.
/// This does not filter out trills, jacks, anchors, etc.
/// </remarks>
public record SinglestreamPattern(
    int OffsetStart, int OffsetEnd, int NoteCount, int ColumnCount, int TotalColumnDistance)
    : INotePattern
{
    public double NotesPerSecond => NoteCount / LengthSeconds;
    public int Length => OffsetEnd - OffsetStart;
    public double LengthSeconds => Length / 1000D;
    public double ColumnHitsPerSecond => NotesPerSecond / ColumnCount;
    public double AverageColumnDistance => (double)TotalColumnDistance / NoteCount;

    public MapAnnotationType Type => MapAnnotationType.Singlestream;
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
