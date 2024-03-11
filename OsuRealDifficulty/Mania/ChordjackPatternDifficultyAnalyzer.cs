namespace OsuRealDifficulty.Mania;

public sealed class ChordjackPatternDifficultyAnalyzer
    : BaseSingleAnnotationFullAnalyzer<ChordjackAnnotation>
{
    public static ChordjackPatternDifficultyAnalyzer Instance { get; } = new();

    // Usually chordjacks involving the special key won't have to
    // be played with alternating fingers
    protected override double SourceChordListWeight => 0.9;

    public override void AnalyzeAnnotations(
        BeatmapAnnotationAnalysisContext context)
    {
        var pressColumnIndices = JackAnalysisHelpers
            .GetPressColumnIndicesWithJackAnnotations(
                context);

        var pressColumns = context.AffectedChordList.PressColumns;
        foreach (var range in pressColumnIndices)
        {
            AnalyzeRange();

            void AnalyzeRange()
            {
                for (int i = range.Start; i < range.End; i++)
                {
                    AnalyzeIndices(i);
                }
            }

            void AnalyzeIndices(int start)
            {
                int end = start + 1;
                var startPress = pressColumns[start];
                var endPress = pressColumns[end];
                var startColumnData = startPress.PressColumns.Data;
                var endColumnData = endPress.PressColumns.Data;
                int commonColumns = startColumnData & endColumnData;
                int popCount = commonColumns.PopCount();

                // We should never encounter a common count of 0,
                // since the merged ranges only combine and merge
                // ranges that actually overlap with each other
                if (popCount is 0)
                {
                    throw new UnreachableException("We found an invalid merged index range.");
                }

                if (popCount < 2)
                    return;

                int startOffset = startPress.Offset;
                int endOffset = endPress.Offset;
                int startExtraNotes = startColumnData ^ commonColumns;
                int endExtraNotes = endColumnData ^ commonColumns;
                int startExtraNotesCount = startExtraNotes.PopCount();
                int endExtraNotesCount = startExtraNotes.PopCount();
                var chordjackAnnotation = new ChordjackAnnotation(
                    startOffset,
                    endOffset,
                    startExtraNotesCount,
                    endExtraNotesCount,
                    new(commonColumns));
                context.AddAnnotation(chordjackAnnotation);
            }
        }
    }

    protected override double CalculatePatternAbsoluteValue(
        ChordjackAnnotation pattern)
    {
        int gap = pattern.PressColumns.Data.GapBits();
        double gapValue = gap * 1.06;
        double timeMultiplier = 300D / pattern.TimeDistance;
        double columnValue = pattern.ColumnCount * 1.2;
        double jackValue = gapValue * columnValue * timeMultiplier;
        double firstExtraNotesValue = pattern.FirstExtraNotes * 0.4;
        double secondExtraNotesValue = pattern.SecondExtraNotes * 0.6;
        double extraNotesValue = firstExtraNotesValue + secondExtraNotesValue;
        double extraValue = extraNotesValue.Pow(1.04);
        double totalValue = jackValue * extraValue;
        // Our numbers have gone overboard, let's trim down some of that power
        return totalValue / 7.5;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Jack.Chordjack;
    }
}
