namespace OsuRealDifficulty.Mania;

public class AnalyzedDifficultyFacts
{
    public const double LogBase = Math.E;

    public static double NormalizeValue(double absoluteValue)
    {
        return Math.Log(absoluteValue, LogBase);
    }
    public static double AbsoluteValue(double normalizedValue)
    {
        return Math.Pow(LogBase, normalizedValue);
    }
}
