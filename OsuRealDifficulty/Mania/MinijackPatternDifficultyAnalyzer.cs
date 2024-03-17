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
        double distanceMultiplier = Math.Pow(200 / timeDistance, 3.35);
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
