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

        // Annotate normal minijacks and anchors
        // + hold info about the jackstream annotations
        var jackstreamRanges = new CommittableRanges();
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

                        // Also commit the ranges as they have been annotated
                        int startIndex = i;
                        int endIndex = i + length - 1;
                        jackstreamRanges.Add(startIndex, endIndex);
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

        // Annotate jackstreams
        jackstreamRanges.FinalizeCommits();
        var committedJackstreamRanges = jackstreamRanges.CommittedRanges;
        var jackstreamAnnotationBuilders
            = new JackstreamAnnotationBuilder[committedJackstreamRanges.Count];

        for (int i = 0; i < committedJackstreamRanges.Count; i++)
        {
            var committedRange = committedJackstreamRanges[i];
            jackstreamAnnotationBuilders[i] = new(committedRange);
        }

        int currentJackstreamAnnotationIndex = 0;
        foreach (var annotation in context.Annotations)
        {
            // We are traversing the beatmap in ascending offset order, therefore
            // all our annotations will be in ascending offset order when enumerated
            // The committed jackstream ranges are also in ascending offset order,
            // which means we can only be off by an index of 1 at most

            ref var currentJackstreamAnnotation
                = ref jackstreamAnnotationBuilders[currentJackstreamAnnotationIndex];

            if (annotation is not INotePattern pattern)
            {
                throw new UnreachableException("We encountered a non-pattern jack annotation");
            }

            int start = pattern.OffsetStart;
            int end = pattern.OffsetEnd;

            int startIndex = JackAnalysisHelpers.PressColumnIndexFromOffset(
                start, chordPressColumns);

            while (!currentJackstreamAnnotation.Range.Contains(startIndex))
            {
                currentJackstreamAnnotationIndex++;
                currentJackstreamAnnotation
                    = ref jackstreamAnnotationBuilders[currentJackstreamAnnotationIndex];
            }

            switch (annotation)
            {
                case MinijackAnnotation minijack:
                    currentJackstreamAnnotation.NoteCount += minijack.NoteCount;
                    currentJackstreamAnnotation.ColumnBits |= minijack.Columns.Data;
                    break;

                case AnchorPattern anchor:
                    currentJackstreamAnnotation.NoteCount += anchor.NoteCount;
                    currentJackstreamAnnotation.ColumnBits |= anchor.Columns.Data;
                    break;
            }
        }

        for (int i = 0; i < jackstreamAnnotationBuilders.Length; i++)
        {
            var builder = jackstreamAnnotationBuilders[i];
            int offsetStart = chordPressColumns[builder.OffsetStart].Offset;
            int offsetEnd = chordPressColumns[builder.OffsetEnd].Offset;
            var finalizedAnnotation = new JackstreamAnnotation(
                offsetStart,
                offsetEnd,
                builder.Range.Length,
                builder.NoteCount,
                builder.ColumnVector);
            context.AddAnnotation(finalizedAnnotation);
        }
    }

    private struct JackstreamAnnotationBuilder(SimpleRange range)
    {
        public readonly SimpleRange Range = range;

        public int NoteCount;
        public int ColumnBits;

        public readonly int OffsetStart => Range.Start;
        public readonly int OffsetEnd => Range.End;

        public readonly BitVector32 ColumnVector => new(ColumnBits);
    }

    private sealed class CommittableRanges
    {
        private readonly List<SimpleRange> _committed = [];

        private int _firstIndex = -1;
        private int _lastIndex = -1;

        public IReadOnlyList<SimpleRange> CommittedRanges => _committed;

        public void Add(int start, int end)
        {
            Debug.Assert(start >= 0 && end >= 0);
            Debug.Assert(start <= end);

            if (_firstIndex < 0)
            {
                _firstIndex = start;
                _lastIndex = end;
                return;
            }

            int startOffset = start - _lastIndex;
            if (startOffset > 1)
            {
                CommitCurrent();
                _firstIndex = start;
                _lastIndex = end;
            }
            else
            {
                _lastIndex = end;
            }
        }

        private void CommitCurrent()
        {
            if (_firstIndex >= 0)
            {
                var range = new SimpleRange(_firstIndex, _lastIndex);
                _committed.Add(range);
                _firstIndex = -1;
                _lastIndex = -1;
            }
        }

        public void FinalizeCommits()
        {
            CommitCurrent();
        }
    }
}
