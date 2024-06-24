namespace OsuRealDifficulty.Mania;

public abstract class BaseSingleAnnotationFullAnalyzer<TPattern>
    : IFullBeatmapNoteAnalyzer, IDiscerningChordListDifficultyAnalyzer
    where TPattern : IMapAnnotation
{
    public abstract void AnalyzeAnnotations(BeatmapAnnotationAnalysisContext context);

    protected abstract double SourceChordListWeight { get; }
    protected double NormalizedChordListWeight => 1 - SourceChordListWeight;

    double IDiscerningChordListDifficultyAnalyzer.SourceChordListWeight
        => SourceChordListWeight;

    public virtual AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context)
    {
        var annotations = context.Annotations
            .OfType<TPattern>()
            .ToList();

        return DifficultyCalculationAlgorithms.Aggregation.SmallDoubleMeans(
            annotations,
            CalculatePatternAbsoluteValue);
    }

    protected abstract double CalculatePatternAbsoluteValue(TPattern pattern);

    public abstract ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty);
}
