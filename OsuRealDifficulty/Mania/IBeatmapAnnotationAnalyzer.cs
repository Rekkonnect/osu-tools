namespace OsuRealDifficulty.Mania;

public interface IBeatmapAnnotationAnalyzer
{
    public ref CalculationResult CalculationResultRef(AnalyzedDifficulty difficulty);

    public void Analyze(BeatmapAnnotationAnalysisContext context);

    public virtual void Analyze(CompleteBeatmapAnnotationAnalysisContext context)
    {
        context.GetChordListSpecificContexts(
            out var sourceChordListContext,
            out var normalizedChordListContext);

        Analyze(sourceChordListContext);

        if (normalizedChordListContext is not null)
        {
            Analyze(normalizedChordListContext.Value);
        }
    }

    public double CalculateDifficultyResult(
        CompleteBeatmapAnnotationAnalysisContext context);
}
