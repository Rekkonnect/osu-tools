namespace OsuRealDifficulty.Mania;

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
