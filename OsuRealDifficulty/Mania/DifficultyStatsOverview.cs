namespace OsuRealDifficulty.Mania;

public record DifficultyStatsOverview(
    SegmentedOverallDifficulty OverallDifficulty,
    CalculationResult InstabilityRate)
{
    public static DifficultyStatsOverview NewPending => new(
        SegmentedOverallDifficulty.NewPending,
        CalculationResult.Pending);

    public CalculationResult StarRate => OverallDifficulty.Overall;
}
