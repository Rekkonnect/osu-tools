namespace OsuRealDifficulty.Mania;

internal static class JackAnalysisHelpers
{
    public static JackAnnotations GetCommittedJackAnnotations(
        BeatmapAnnotationAnalysisContext context)
    {
        return new(
            context.CommittedAnnotations.OfType<MinijackAnnotation>(),
            context.CommittedAnnotations.OfType<AnchorPattern>()
            );
    }

    public static List<SimpleRange> GetPressColumnIndicesWithJackAnnotations(
        BeatmapAnnotationAnalysisContext context)
    {
        var chordOffsets = GetChordOffsetsWithJackAnnotations(context);
        var indexRanges = chordOffsets.Select(
            offset => PressColumnIndexRangeFromOffsetRange(
                context,
                offset));
        return indexRanges.ToList();
    }

    private static SimpleRange PressColumnIndexRangeFromOffsetRange(
        BeatmapAnnotationAnalysisContext context,
        SimpleRange offsetRange)
    {
        var (start, end) = offsetRange;
        int startIndex = PressColumnIndexFromOffset(context, start);
        int endIndex = PressColumnIndexFromOffset(context, end);
        return new(startIndex, endIndex);
    }

    private static int PressColumnIndexFromOffset(
        BeatmapAnnotationAnalysisContext context, int offset)
    {
        var pressColumns = context.AffectedChordList.PressColumns;
        var target = ChordPressColumns.EmptyForOffset(offset);
        return pressColumns.BinarySearch(
            target,
            ChordPressColumns.AscendingOffsetComparer.Instance);
    }

    public static List<SimpleRange> GetChordOffsetsWithJackAnnotations(
        BeatmapAnnotationAnalysisContext context)
    {
        var rangesByStart = new SortedDictionary<int, SimpleRange>();

        var committed = GetCommittedJackAnnotations(context);

        // Anchors have higher precedence due to the larger range they cover

        // Anchors
        foreach (var anchor in committed.Anchors)
        {
            int start = anchor.OffsetStart;
            int end = anchor.OffsetEnd;
            // Try searching first if it exists
            bool contained = rangesByStart.TryGetValue(start, out var existingRange);
            if (contained)
            {
                int containedEnd = existingRange.End;
                if (containedEnd >= end)
                {
                    // Skip this anchor, as we have another anchor superseding this one
                    continue;
                }
            }

            rangesByStart[start] = new(start, end);
        }

        // Minijacks
        foreach (var minijack in committed.Minijacks)
        {
            int start = minijack.OffsetStart;
            int end = minijack.OffsetEnd;

            bool contained = rangesByStart.TryGetValue(start, out var existingRange);
            if (contained)
            {
                int containedEnd = existingRange.End;
                if (containedEnd >= end)
                {
                    // Skip this minijack, as we have another anchor superseding this one
                    continue;
                }
            }

            rangesByStart[start] = new(start, end);
        }

        var rangeList = new List<SimpleRange>();

        foreach (var range in rangesByStart.Values)
        {
            if (rangeList.Count is 0)
            {
                rangeList.Add(range);
                continue;
            }

            // Try merging the last range
            var lastRange = rangeList.Last();
            if (lastRange.End >= range.Start)
            {
                // Only if our new range ends further than
                // the last analyzed range
                if (lastRange.End < range.End)
                {
                    var mergedRange = new SimpleRange(
                        lastRange.Start, range.End);
                    rangeList[^1] = mergedRange;
                }
            }
            else
            {
                rangeList.Add(range);
            }
        }

        return rangeList;
    }
}
