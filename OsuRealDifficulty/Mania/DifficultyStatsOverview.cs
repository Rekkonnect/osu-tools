namespace OsuRealDifficulty.Mania;

public class DifficultyStatsOverview(
    SegmentedOverallDifficulty overallDifficulty,
    CalculationResult instabilityRate)
{
    public static DifficultyStatsOverview NewPending => new(
        SegmentedOverallDifficulty.NewPending,
        CalculationResult.Pending);

    public SegmentedOverallDifficulty OverallDifficulty = overallDifficulty;
    public CalculationResult InstabilityRate = instabilityRate;

    public CalculationResult StarRate => OverallDifficulty.Overall;
}
