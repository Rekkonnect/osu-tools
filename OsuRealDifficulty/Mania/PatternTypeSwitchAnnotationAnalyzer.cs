namespace OsuRealDifficulty.Mania;

public sealed class PatternTypeSwitchAnnotationAnalyzer
    : BaseSingleAnnotationFullAnalyzer<PatternTypeSwitchAnnotation>
{
    public static PatternTypeSwitchAnnotationAnalyzer Instance { get; } = new();

    protected override double SourceChordListWeight => 0.6;

    public override void AnalyzeAnnotations(BeatmapAnnotationAnalysisContext context)
    {
        throw new NotImplementedException();
    }

    protected override double CalculatePatternAbsoluteValue(
        PatternTypeSwitchAnnotation pattern)
    {
        return 0;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Tech.PatternTypeSwitch;
    }
}
