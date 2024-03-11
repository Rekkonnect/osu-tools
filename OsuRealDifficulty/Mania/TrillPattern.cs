namespace OsuRealDifficulty.Mania;

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
    public int TimeDistance => OffsetEnd - OffsetStart;
    public double LengthSeconds => TimeDistance / 1000D;
    public double ColumnHitsPerSecond => NotesPerSecond / ColumnCount;

    public MapAnnotationType Type => MapAnnotationType.Trill;
}
