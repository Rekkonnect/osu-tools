namespace OsuRealDifficulty.Mania;

public record FullDifficultyCalculationResult(
    DifficultyStatsOverview Overview,
    AnalyzedDifficulty AnalyzedDifficulty)
{
    public static FullDifficultyCalculationResult NewPending => new(
        DifficultyStatsOverview.NewPending,
        AnalyzedDifficulty.NewPending);
}
