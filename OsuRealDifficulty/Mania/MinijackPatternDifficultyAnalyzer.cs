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
