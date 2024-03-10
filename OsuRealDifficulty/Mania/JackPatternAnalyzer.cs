namespace OsuRealDifficulty.Mania;

public sealed class JackPatternAnalyzer
    : IBeatmapAnnotationAnalyzer
{
    public static JackPatternAnalyzer Instance { get; } = new();

    public void AnalyzeAnnotations(BeatmapAnnotationAnalysisContext context)
    {
        var chordPressColumns = context.AffectedChordList.NonEmptyPressColumns;
        chordPressColumns.DeconstructLists(out var chords, out var pressColumns);

        const int maxTimeDistance = 400;

        int maxStartIndex = chords.Length - 1;
        for (int i = 0; i < maxStartIndex; i++)
        {
            AnalyzeCurrentPosition();

            void AnalyzeCurrentPosition()
            {
                int length = 1;
                int firstOffset = chords[i].Offset;
                int commonColumns = pressColumns[i].Data;
                int lastCommittedOffset = firstOffset;
                while (true)
                {
                    int nextIndex = i + length;
                    if (nextIndex >= chords.Length)
                        break;

                    var chord = chords[nextIndex];
                    int chordOffset = chord.Offset;
                    int offsetDifference = chordOffset - lastCommittedOffset;
                    if (offsetDifference > maxTimeDistance)
                        break;

                    var chordPress = pressColumns[nextIndex];
                    var nextCommon = chordPress.Data & commonColumns;

                    // The jack session ends here
                    if (nextCommon is 0)
                        break;

                    // We don't have all common columns
                    if (nextCommon != commonColumns)
                    {
                        // Commit the columns that end early
                        var endingColumns = nextCommon ^ commonColumns;
                        CommitCurrentInt(endingColumns);
                        commonColumns = nextCommon;
                    }

                    // We commit the inclusion of the chord
                    length++;
                    lastCommittedOffset = chordOffset;
                }

                CommitCurrentInt(commonColumns);

                void CommitCurrentInt(int columns)
                {
                    CommitCurrent(new BitVector32(columns));
                }

                void CommitCurrent(BitVector32 columns)
                {
                    var annotation = CreateAnnotation();

                    if (annotation is not null)
                    {
                        // We remove the committed presses to avoid encountering
                        // them in future iterations of the analysis
                        TrimPressColumns(columns);
                        context.AddAnnotation(annotation);
                    }

                    IMapAnnotation? CreateAnnotation()
                    {
                        return length switch
                        {
                            2 => new MinijackAnnotation(
                                    firstOffset,
                                    lastCommittedOffset,
                                    columns),
                            >= 3 => new AnchorPattern(
                                    firstOffset,
                                    lastCommittedOffset,
                                    HitCount: length,
                                    columns),

                            // It's not a jack
                            _ => null,
                        };
                    }
                }

                void TrimPressColumns(BitVector32 columns)
                {
                    for (int indexOffset = 0; indexOffset < length; indexOffset++)
                    {
                        int removedIndex = i + indexOffset;
                        ref var removedPress = ref pressColumns[removedIndex];
                        int newData = removedPress.Data & ~columns.Data;
                        removedPress = new(newData);
                    }
                }
            }
        }
    }
}
