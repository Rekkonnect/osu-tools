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

public interface IDiscerningChordListDifficultyAnalyzer
    : IBeatmapDifficultyAnalyzer
{
    protected abstract double SourceChordListWeight { get; }
    protected double NormalizedChordListWeight => 1 - SourceChordListWeight;

    double IBeatmapDifficultyAnalyzer.CalculateDifficultyResult(
        CompleteBeatmapAnnotationAnalysisContext context)
    {
        context.GetChordListSpecificContexts(
            out var sourceChordListContext,
            out var normalizedChordListContext);

        var sourceValue = CalculateDifficultyResult(sourceChordListContext);
        var resultingValue = sourceValue;

        if (normalizedChordListContext is not null && NormalizedChordListWeight > 0)
        {
            var normalizedAbsoluteValue = CalculateDifficultyResult(
                normalizedChordListContext.Value);

            resultingValue = new AnalysisDifficultyValue(
                sourceValue.AbsoluteValue * SourceChordListWeight +
                normalizedAbsoluteValue.AbsoluteValue * NormalizedChordListWeight);
        }

        return resultingValue.NormalizedValue;
    }

    protected abstract AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context);
}

public abstract class BaseSingleAnnotationFullAnalyzer<TPattern>
    : IFullBeatmapNoteAnalyzer
    where TPattern : IMapAnnotation
{
    public abstract void AnalyzeAnnotations(BeatmapAnnotationAnalysisContext context);

    protected abstract double SourceChordListWeight { get; }
    protected double NormalizedChordListWeight => 1 - SourceChordListWeight;

    public double CalculateDifficultyResult(CompleteBeatmapAnnotationAnalysisContext context)
    {
        context.GetChordListSpecificContexts(
            out var sourceChordListContext,
            out var normalizedChordListContext);

        var sourceValue = CalculateDifficultyResult(sourceChordListContext);
        var resultingValue = sourceValue;

        if (normalizedChordListContext is not null && NormalizedChordListWeight > 0)
        {
            var normalizedAbsoluteValue = CalculateDifficultyResult(
                normalizedChordListContext.Value);

            resultingValue = new AnalysisDifficultyValue(
                sourceValue.AbsoluteValue * SourceChordListWeight +
                normalizedAbsoluteValue.AbsoluteValue * NormalizedChordListWeight);
        }

        return resultingValue.NormalizedValue;
    }

    protected virtual AnalysisDifficultyValue CalculateDifficultyResult(
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
