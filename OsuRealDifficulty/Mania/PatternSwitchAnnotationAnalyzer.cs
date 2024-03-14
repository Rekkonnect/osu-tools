namespace OsuRealDifficulty.Mania;

public sealed class PatternSwitchAnnotationAnalyzer
    : BaseSingleAnnotationFullAnalyzer<PatternSwitchAnnotation>
{
    public static PatternSwitchAnnotationAnalyzer Instance { get; } = new();

    protected override double SourceChordListWeight => 0.6;

    public override void AnalyzeAnnotations(BeatmapAnnotationAnalysisContext context)
    {
        context.AnalyzerDiagnostics.Add(new("Reporting that this analyzer is not yet done"));
    }

    protected override double CalculatePatternAbsoluteValue(
        PatternSwitchAnnotation pattern)
    {
        return 0;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Tech.PatternSwitch;
    }
}
