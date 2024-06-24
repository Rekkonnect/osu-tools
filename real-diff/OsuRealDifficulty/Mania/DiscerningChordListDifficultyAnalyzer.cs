namespace OsuRealDifficulty.Mania;

public abstract class DiscerningChordListDifficultyAnalyzer
    : IDiscerningChordListDifficultyAnalyzer
{
    protected abstract double SourceChordListWeight { get; }
    protected double NormalizedChordListWeight => 1 - SourceChordListWeight;

    double IDiscerningChordListDifficultyAnalyzer.SourceChordListWeight
        => SourceChordListWeight;

    public abstract AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context);

    public abstract ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty);
}
