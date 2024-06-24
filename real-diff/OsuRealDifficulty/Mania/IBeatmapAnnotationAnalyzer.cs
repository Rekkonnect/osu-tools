namespace OsuRealDifficulty.Mania;

/// <summary>
/// Denotes a beatmap analyzer without any defined behavior.
/// </summary>
public interface IBeatmapAnalyzer;

/// <summary>
/// A beatmap annotation analyzer is only responsible for producing annotations
/// after analyzing the beatmap. This includes both analysis of the source
/// chord list, and the normalized chord list for odd-key chord lists.
/// </summary>
public interface IBeatmapAnnotationAnalyzer : IBeatmapAnalyzer
{
    public abstract void AnalyzeAnnotations(BeatmapAnnotationAnalysisContext context);

    public virtual void AnalyzeAnnotations(CompleteBeatmapAnnotationAnalysisContext context)
    {
        context.GetChordListSpecificContexts(
            out var sourceChordListContext,
            out var normalizedChordListContext);

        AnalyzeAnnotations(sourceChordListContext);

        if (normalizedChordListContext is not null)
        {
            AnalyzeAnnotations(normalizedChordListContext.Value);
        }
    }
}

/// <summary>
/// A beatmap difficulty analyzer is only responsible for calculating the difficulty
/// of a specific skill, given the chord lists and the produced annotations.
/// For multiple difficulty skills, a separate analyzer must be created.
/// </summary>
public interface IBeatmapDifficultyAnalyzer : IBeatmapAnalyzer
{
    /// <summary>
    /// Calculates the difficulty result after having performed an analysis
    /// given the provided <paramref name="context"/>.
    /// </summary>
    /// <param name="context">
    /// During an analysis driver execution, this context has been previously
    /// passed onto <see cref="AnalyzeAnnotations(CompleteBeatmapAnnotationAnalysisContext)"/>.
    /// </param>
    /// <returns>
    /// The normalized difficulty value.
    /// </returns>
    public double CalculateDifficultyResult(
        CompleteBeatmapAnnotationAnalysisContext context);

    public ref CalculationResult CalculationResultRef(AnalyzedDifficulty difficulty);
}
