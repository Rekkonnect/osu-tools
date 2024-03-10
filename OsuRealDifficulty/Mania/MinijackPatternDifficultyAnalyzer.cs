namespace OsuRealDifficulty.Mania;

public sealed class MinijackPatternDifficultyAnalyzer
    : DiscerningChordListDifficultyAnalyzer
{
    public static MinijackPatternDifficultyAnalyzer Instance { get; } = new();

    protected override double SourceChordListWeight => 0.4;

    public override AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context)
    {
        var minijacks = context.CommittedAnnotations.OfType<MinijackAnnotation>();
        double absoluteValue = 0;

        foreach (var minijack in minijacks)
        {
            var minijackValue = AbsoluteValueForMinijack(minijack);
            absoluteValue += minijackValue;
        }

        return new(absoluteValue);
    }

    private double AbsoluteValueForMinijack(MinijackAnnotation minijack)
    {
        // Slow jacks are worth little, while fast jacks are worth a lot more
        double timeDistance = minijack.TimeDistance;
        double distanceMultiplier = Math.Pow(250 / timeDistance, 1.6);
        double columnBase = minijack.ColumnCount * 0.92;
        double columnCountMultiplier = Math.Pow(columnBase, 0.92);
        return distanceMultiplier * columnCountMultiplier;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Jack.Minijack;
    }
}

public sealed class ChordjackPatternDifficultyAnalyzer
    : BaseSingleAnnotationFullAnalyzer<ChordjackAnnotation>
{
    public static ChordjackPatternDifficultyAnalyzer Instance { get; } = new();

    // Usually chordjacks involving the special key are not that
    // significant
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
                var chordjackAnnotation = new ChordjackAnnotation(
                    startOffset, endOffset, new(commonColumns));
                context.AddAnnotation(chordjackAnnotation);
            }
        }
    }

    protected override double CalculatePatternAbsoluteValue(
        ChordjackAnnotation pattern)
    {
        throw new NotImplementedException();
    }

    public override AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context)
    {
        double absoluteValue = 0;

        var annotations = context.Annotations;
        foreach (var annotation in annotations)
        {
            if (annotation is not ChordjackAnnotation chordjack)
                continue;

            var chordjackValue = AbsoluteValueForChordjack(chordjack);
            absoluteValue += chordjackValue;
        }

        return new(absoluteValue);
    }

    private double AbsoluteValueForChordjack(ChordjackAnnotation chordjack)
    {
        return 0;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Jack.Chordjack;
    }
}
