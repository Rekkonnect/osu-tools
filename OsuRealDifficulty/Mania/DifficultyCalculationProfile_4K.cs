namespace OsuRealDifficulty.Mania;

public class DifficultyCalculationProfile_4K()
    : CustomDifficultyCalculationProfile(StarWeights, InstabilityWeights)
{
    public static DifficultyCalculationProfile_4K Instance { get; }

    public static readonly AnalyzedDifficulty StarWeights = new()
    {
        Dexterity = new()
        {
            Speed = 0.96,
            Chord = 1,
            Dump = 0.6,
            Trill = 0.92,
            ChordGap = 0.85,
            Singlestream = 1,
        },
        Jack = new()
        {
            Minijack = 0.8,
            Chordjack = 1,
            Anchor = 1,
            Jackstream = 1,
            Fieldjack = 0.95,
            DoubleHandJack = 1,
        },
        Tech = new()
        {
            PatternSwitch = 1,
            RhythmIrregularity = 1,
            Flam = 0.9,
        },
        Stamina = new()
        {
            LongBurst = 1,
            SteadyRateStream = 1,
            SingleHandTrill = 1,
        },
        LongNotes = new()
        {
            RiceMix = 0.65,
            RiceLN = 0.2,
            Inverse = 0.7,
            Shield = 0.8,
            LNShield = 0.5,
        },
        Scrolling = new()
        {
            Slow = 0.9,
            Fast = 1,
            Burst = 1,
            Stutter = 0.85,
            VisualDensity = 1,
        },
    };

    public static readonly AnalyzedDifficulty InstabilityWeights = new()
    {
        Dexterity = new()
        {
            Speed = 0.64,
            Chord = 0.25,
            Dump = 0.2,
            Trill = 0.8,
            ChordGap = 0.6,
            Singlestream = 0.85,
        },
        Jack = new()
        {
            Minijack = 1,
            Chordjack = 0.4,
            Anchor = 0.2,
            Jackstream = 0.3,
            Fieldjack = 0.3,
            DoubleHandJack = 0.75,
        },
        Tech = new()
        {
            PatternSwitch = 1,
            RhythmIrregularity = 1,
            Flam = 0.85,
        },
        Stamina = new()
        {
            LongBurst = 0.35,
            SteadyRateStream = 0.25,
            SingleHandTrill = 0.9,
        },
        LongNotes = new()
        {
            RiceMix = 0.15,
            RiceLN = 0.4,
            Inverse = 0.2,
            Shield = 0.25,
            LNShield = 0.3,
        },
        Scrolling = new()
        {
            Slow = 0.8,
            Fast = 0.6,
            Burst = 1,
            Stutter = 0.7,
            VisualDensity = 0.1,
        },
    };

    static DifficultyCalculationProfile_4K()
    {
        Instance = new();
    }
}
