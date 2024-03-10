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
        var annotations = context.Annotations;

        double absoluteValue = 0;
        foreach (var annotation in annotations)
        {
            if (annotation is not TPattern pattern)
                continue;

            absoluteValue += CalculatePatternAbsoluteValue(pattern);
        }

        return new(absoluteValue);
    }

    protected abstract double CalculatePatternAbsoluteValue(TPattern pattern);

    public abstract ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty);
}
