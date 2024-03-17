namespace OsuRealDifficulty.Mania;

public sealed class FieldjackPatternDifficultyAnalyzer
    : BaseSingleAnnotationFullAnalyzer<FieldjackAnnotation>
{
    public static FieldjackPatternDifficultyAnalyzer Instance { get; } = new();

    // fieldjacks can be alternated when using the special key
    protected override double SourceChordListWeight => 0.4;

    public override void AnalyzeAnnotations(
        BeatmapAnnotationAnalysisContext context)
    {
        var pressColumnIndices = JackAnalysisHelpers
            .GetPressColumnIndicesWithJackAnnotations(
                context);

        var pressColumns = context.AffectedChordList.NonEmptyPressColumns;
        int sourceKeys = context.BeatmapInfo.ChordList.Keys;
        foreach (var range in pressColumnIndices)
        {
            AnalyzeRange();

            void AnalyzeRange()
            {
                for (int i = range.Start; i < range.End; i++)
                {
                    AnalyzeIndices(ref i);
                }
            }

            void AnalyzeIndices(ref int start)
            {
                int end = start + 1;
                var startPress = pressColumns[start];
                var endPress = pressColumns[end];
                var startColumnData = startPress.PressColumns.Data;
                var endColumnData = endPress.PressColumns.Data;

                int startPressCount = startColumnData.PopCount();
                int endPressCount = endColumnData.PopCount();

                bool isFieldBased = startPressCount == sourceKeys;
                bool isFieldTrailing = endPressCount == sourceKeys;

                if (!isFieldBased && !isFieldTrailing)
                {
                    // we have no field presses, so we have no fieldjack
                    return;
                }

                int commonColumns = startColumnData & endColumnData;
                int popCount = commonColumns.PopCount();

                // we should never encounter a common count of 0,
                // since the merged ranges only combine and merge
                // ranges that actually overlap with each other
                if (popCount is 0)
                {
                    throw new UnreachableException("We found an invalid merged index range.");
                }

                int startOffset = startPress.Offset;
                int endOffset = endPress.Offset;
                var fieldjackAnnotation = new FieldjackAnnotation(
                    startOffset,
                    endOffset,
                    startPressCount,
                    endPressCount,
                    new(commonColumns));
                context.AddAnnotation(fieldjackAnnotation);

                // skip the next index to avoid registering the same field press more than
                // once in a regular stream of fieldjacks
                if (isFieldBased)
                {
                    start++;
                }
            }
        }
    }

    protected override double CalculatePatternAbsoluteValue(
        FieldjackAnnotation pattern)
    {
        int gap = pattern.PressColumns.Data.GapBits();
        double gapValue = gap * 1.06;
        if (gap is 0)
            gapValue = 0.5;

        double timeMultiplier = 300D / pattern.TimeDistance;
        double columnValue = pattern.ColumnCount * 1.2;
        double jackValue = gapValue * columnValue * timeMultiplier;
        double firstNotesValue = pattern.FirstNoteCount * 0.1;
        double secondNotesValue = pattern.SecondNoteCount * 0.2;
        if (pattern.AreBothFieldPresses)
        {
            // nerf the second field press since it's not a difficult pattern
            secondNotesValue = firstNotesValue;
        }

        double notesValueMultiplier = firstNotesValue + secondNotesValue + 1;
        double notesValuePowered = notesValueMultiplier.Pow(1.015);
        double totalValue = jackValue * notesValuePowered;
        return totalValue / 6;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Jack.Fieldjack;
    }
}
