namespace OsuRealDifficulty.Mania;

public sealed class SinglestreamPatternAnalyzer
    : BaseSinglePatternAnalyzer<SinglestreamPattern>
{
    public static SinglestreamPatternAnalyzer Instance { get; } = new();

    protected override double SourceChordListWeight => 0.65;

    public override void Analyze(BeatmapAnnotationAnalysisContext context)
    {
        var chordPressColumns = context.AffectedChordList.NonEmptyPressColumns;
        chordPressColumns.DeconstructLists(out var chords, out var pressColumns);

        const int minStreamLength = 3;

        // 750ms is long enough to not count as a singlestream for any purpose
        // Besides, most beginner maps are singlestreams in nature
        const int maxTimeDistance = 750;

        int maxStartIndex = chords.Length - minStreamLength + 1;
        for (int i = 0; i < maxStartIndex; i++)
        {
            AnalyzeCurrentPosition();

            void AnalyzeCurrentPosition()
            {
                int length = 0;
                int totalColumnDistance = 0;
                int previousSingleIndex = 0;
                int firstOffset = chords[i].Offset;
                int lastCommittedOffset = firstOffset;
                var columnBits = 0;
                while (true)
                {
                    int nextIndex = i + length + 1;
                    if (nextIndex >= chords.Length)
                        break;

                    var chord = chords[nextIndex];
                    int chordOffset = chord.Offset;
                    int offsetDifference = chordOffset - lastCommittedOffset;
                    if (offsetDifference > maxTimeDistance)
                        break;

                    var chordPress = pressColumns[nextIndex];
                    int pressCount = chordPress.PopCount();
                    if (pressCount is not 1)
                        break;

                    // Hereon we have accepted the chord as part of the pattern

                    int singleIndex = chordPress.FirstBitIndex();
                    columnBits |= chordPress.Data;

                    if (length > 0)
                    {
                        int columnDistance = Math.Abs(singleIndex - previousSingleIndex);
                        totalColumnDistance += columnDistance;
                    }

                    // We commit the inclusion of the chord
                    length++;
                    previousSingleIndex = singleIndex;
                    lastCommittedOffset = chordOffset;
                }

                // We have analyzed the continuous singlestreams from the earliest
                // possible index, and therefore we can completely skip these indices
                // regardless of whether we actually register a singlestream annotation
                i += length;

                if (length < minStreamLength)
                    return;

                int columnCount = columnBits.PopCount();
                var pattern = new SinglestreamPattern(
                    firstOffset,
                    lastCommittedOffset,
                    NoteCount: length,
                    columnCount,
                    totalColumnDistance);

                context.AddAnnotation(pattern);
            }
        }
    }

    protected override double CalculatePatternAbsoluteValue(SinglestreamPattern pattern)
    {
        // Do not buff difficulty the denser the singlestream
        // becomes due to a lower column count, neither on how
        // more spread it becomes inversely
        // Other analyzers will be handling each specific pattern
        // more gracefully

        // Column distance matters more for parsing difficulty
        var columnDistance = pattern.TotalColumnDistance;
        var normalizedColumnDistance = Math.Log(columnDistance);
        var averageDistance = pattern.AverageColumnDistance;
        var noteCount = pattern.NoteCount;
        var nps = pattern.NotesPerSecond;
        double intensity = 2D - (2D / (noteCount - 2));
        var value = nps * columnDistance / 3;
        return value;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Dexterity.Singlestream;
    }
}
