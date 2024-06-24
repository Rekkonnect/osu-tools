namespace OsuRealDifficulty.Mania;

public struct SegmentedOverallDifficulty
{
    public static SegmentedOverallDifficulty NewPending => new()
    {
        Overall = CalculationResult.Pending,

        Dexterity = CalculationResult.Pending,
        Jack = CalculationResult.Pending,
        Tech = CalculationResult.Pending,
        Stamina = CalculationResult.Pending,
        LongNotes = CalculationResult.Pending,
        Scrolling = CalculationResult.Pending,
    };

    public CalculationResult Overall;

    public CalculationResult Dexterity;
    public CalculationResult Jack;
    public CalculationResult Tech;
    public CalculationResult Stamina;
    public CalculationResult LongNotes;
    public CalculationResult Scrolling;
}
