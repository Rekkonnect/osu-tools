namespace OsuRealDifficulty.Mania;

public sealed class MinijackPatternDifficultyAnalyzer
    : DiscerningChordListDifficultyAnalyzer
{
    public static MinijackPatternDifficultyAnalyzer Instance { get; } = new();

    protected override double SourceChordListWeight => 0.4;

    public override AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context)
    {
        var annotations = context.CommittedAnnotations
            .OfType<MinijackAnnotation>()
            .ToList();

        return DifficultyCalculationAlgorithms.Aggregation.SmallDoubleMeans(
            annotations,
            AbsoluteValueForMinijack);
    }

    private double AbsoluteValueForMinijack(MinijackAnnotation minijack)
    {
        double timeDistance = minijack.TimeDistance;
        double distanceMultiplier = Math.Pow(200 / timeDistance, 1.6);
        double columnBase = 1 + minijack.ColumnCount * 0.3;
        double columnCountMultiplier = Math.Pow(columnBase, 0.87);
        return distanceMultiplier * columnCountMultiplier / 4;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Jack.Minijack;
    }
}
