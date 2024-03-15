namespace OsuRealDifficulty.Mania;

public abstract class DifficultyCalculationProfile
{
    public abstract DifficultyStatsOverview Calculate(AnalyzedDifficulty difficulty);

    public FullDifficultyCalculationResult CalculateFullResult(AnalyzedDifficulty difficulty)
    {
        var overview = Calculate(difficulty);
        return new(overview, difficulty);
    }
}
