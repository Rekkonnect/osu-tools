namespace OsuRealDifficulty.Mania;

public class DifficultyCalculationProfile_4K()
    : CustomDifficultyCalculationProfile(StarWeights, InstabilityWeights)
{
    public static DifficultyCalculationProfile_4K Instance { get; }

    public static readonly AnalyzedDifficulty StarWeights = new()
    {
        Dexterity = new()
        {
            Speed = 0.48,
            Chord = 0.5,
            Dump = 0.3,
            Trill = 0.46,
            ChordGap = 0.43,
            Singlestream = 0.5,
        },
        Jack = new()
        {
            Minijack = 0.4,
            Chordjack = 0.5,
            Anchor = 0.5,
            Jackstream = 0.5,
            Fieldjack = 0.47,
            DoubleHandJack = 0.5,
        },
        Tech = new()
        {
            PatternSwitch = 0.5,
            RhythmIrregularity = 0.5,
            Flam = 0.45,
        },
        Stamina = new()
        {
            LongBurst = 0.5,
            SteadyRateStream = 0.5,
            SingleHandTrill = 0.5,
        },
        LongNotes = new()
        {
            RiceMix = 0.37,
            RiceLN = 0.15,
            Inverse = 0.35,
            Shield = 0.4,
            LNShield = 0.38,
        },
        Scrolling = new()
        {
            Slow = 0.45,
            Fast = 0.5,
            Burst = 0.5,
            Stutter = 0.37,
            VisualDensity = 0.5,
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
