namespace OsuRealDifficulty.Mania;

public static class AnalysisHelpers
{
    public static List<int> GetChordListOffsetsInvolvingAnnotations(
        BeatmapAnnotationAnalysisContext context,
        IReadOnlyList<IMapAnnotation> annotations)
    {
        var result = new List<int>();
        GetChordListOffsetsInvolvingAnnotations(
            context,
            annotations,
            result);
        return result;
    }

    public static void GetChordListOffsetsInvolvingAnnotations(
        BeatmapAnnotationAnalysisContext context,
        IReadOnlyList<IMapAnnotation> annotations,
        List<int> offsetList)
    {
        var chordList = context.AffectedChordList.ChordList;
        var chords = chordList.Chords;
        foreach (var annotation in annotations)
        {
            switch (annotation)
            {
                case ITwoNotePattern twoNote:
                    AddFromTwoNotePattern(twoNote);
                    break;

                case IPattern pattern:
                    AddFromPattern(pattern);
                    break;

                case ISinglePointAnnotation singlePoint:
                    AddFromSinglePointAnnotation(singlePoint);
                    break;
            }
        }

        void AddFromSinglePointAnnotation(
            ISinglePointAnnotation singlePoint)
        {
            offsetList.Add(singlePoint.Offset);
        }
        void AddFromTwoNotePattern(ITwoNotePattern twoNote)
        {
            offsetList.Add(twoNote.FirstOffset);
            offsetList.Add(twoNote.SecondOffset);
        }
        void AddFromPattern(IPattern pattern)
        {
            var startTargetChord
                = Chord.WithOffset(pattern.OffsetStart);
            var endTargetChord
                = Chord.WithOffset(pattern.OffsetEnd);
            int startIndex = chords.BinarySearch(
                startTargetChord, Chord.AscendingOffsetComparer.Instance);
            int endIndex = chords.BinarySearch(
                endTargetChord, Chord.AscendingOffsetComparer.Instance);

            if (startIndex < 0)
            {
                throw new UnreachableException("Unexpectedly failed to find the start chord");
            }
            if (endIndex < 0)
            {
                throw new UnreachableException("Unexpectedly failed to find the end chord");
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                var chord = chords[i];
                var offset = chord.Offset;
                offsetList.Add(offset);
            }
        }
    }

    public static void GetPressColumnsOffsetsInvolvingAnnotations(
        BeatmapAnnotationAnalysisContext context,
        IReadOnlyList<IMapAnnotation> annotations,
        List<int> offsetList)
    {
        // TODO
    }
}
