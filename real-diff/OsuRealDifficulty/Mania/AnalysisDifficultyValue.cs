namespace OsuRealDifficulty.Mania;

public record struct AnalysisDifficultyValue(double AbsoluteValue)
{
    public static AnalysisDifficultyValue NormalizedZero => FromNormalizedValue(0);

    public readonly double NormalizedValue
        => AnalyzedDifficultyFacts.NormalizeValue(AbsoluteValue);

    public static AnalysisDifficultyValue FromNormalizedValue(double normalizedValue)
    {
        var absoluteValue = AnalyzedDifficultyFacts.AbsoluteValue(normalizedValue);
        return new(absoluteValue);
    }
}
