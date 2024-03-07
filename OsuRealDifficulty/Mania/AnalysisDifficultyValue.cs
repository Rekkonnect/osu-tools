namespace OsuRealDifficulty.Mania;

public record struct AnalysisDifficultyValue(double AbsoluteValue)
{
    public readonly double NormalizedValue
        => AnalyzedDifficultyFacts.NormalizeValue(AbsoluteValue);

    public static AnalysisDifficultyValue FromNormalizedValue(double normalizedValue)
    {
        var absoluteValue = AnalyzedDifficultyFacts.AbsoluteValue(normalizedValue);
        return new(absoluteValue);
    }
}
