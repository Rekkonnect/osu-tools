namespace OsuRealDifficulty.Mania;

public record EstimatedDifficultyStats(
    SegmentedOverallDifficulty OverallDifficulty,
    double InstabilityRate)
{
    public double StarRate => OverallDifficulty.Overall;
}
