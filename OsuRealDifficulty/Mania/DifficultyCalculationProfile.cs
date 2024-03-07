namespace OsuRealDifficulty.Mania;

public abstract class DifficultyCalculationProfile
{
    public abstract EstimatedDifficultyStats Calculate(AnalyzedDifficulty difficulty);
}
