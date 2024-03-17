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
        var annotations = context.CommittedAnnotations
            .OfType<AnchorPattern>()
            .ToList();

        return DifficultyCalculationAlgorithms.Aggregation.SmallDoubleMeans(
            annotations,
            AbsoluteValueForAnchor);
    }

    private double AbsoluteValueForAnchor(AnchorPattern anchor)
    {
        double averageTimeDistance = anchor.AverageTimeDistance;
        double distanceMultiplier = Math.Pow(200 / averageTimeDistance, 1.6);
        double hitCountMultiplier = Math.Log(anchor.HitCount - 1, 2);
        double columnBase = anchor.ColumnCount;
        double columnCountMultiplier = Math.Pow(columnBase, 0.97);
        return distanceMultiplier * columnCountMultiplier * hitCountMultiplier;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Jack.Anchor;
    }
}
