namespace OsuRealDifficulty.Mania;

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
    public int TimeDistance => OffsetEnd - OffsetStart;
    public double LengthSeconds => TimeDistance / 1000D;
    public double ColumnHitsPerSecond => NotesPerSecond / ColumnCount;
    public double AverageColumnDistance => (double)TotalColumnDistance / NoteCount;

    public MapAnnotationType Type => MapAnnotationType.Singlestream;
}
