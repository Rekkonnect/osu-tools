namespace OsuRealDifficulty.Mania;

public sealed class AnchorPatternDifficultyAnalyzer
    : DiscerningChordListDifficultyAnalyzer
{
    public static AnchorPatternDifficultyAnalyzer Instance { get; } = new();

    // Most of the time, anchoring on the special key is meant to preserve
    // the sync of the index finger
    protected override double SourceChordListWeight => 0.85;

    public override AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context)
    {
        var anchors = context.CommittedAnnotations.OfType<AnchorPattern>();
        double absoluteValue = 0;

        foreach (var anchor in anchors)
        {
            var anchorValue = AbsoluteValueForMinijack(anchor);
            absoluteValue += anchorValue;
        }

        return new(absoluteValue);
    }

    private double AbsoluteValueForMinijack(AnchorPattern minijack)
    {
        double averageTimeDistance = minijack.AverageTimeDistance;
        double distanceMultiplier = Math.Pow(200 / averageTimeDistance, 1.6);
        double hitCountMultiplier = Math.Log(minijack.HitCount - 2, 2);
        double columnBase = minijack.ColumnCount;
        double columnCountMultiplier = Math.Pow(columnBase, 0.97);
        return distanceMultiplier * columnCountMultiplier * hitCountMultiplier;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Jack.Anchor;
    }
}
