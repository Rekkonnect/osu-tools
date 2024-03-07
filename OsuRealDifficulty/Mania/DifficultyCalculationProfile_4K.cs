namespace OsuRealDifficulty.Mania;

public class DifficultyCalculationProfile_4K()
    : CustomDifficultyCalculationProfile(StarWeights, InstabilityWeights)
{
    public static DifficultyCalculationProfile_4K Instance { get; } = new();

    public static readonly AnalyzedDifficulty StarWeights = new()
    {
        Jack = new()
        {
            Minijack = 0.8,
            Anchor = 1,
            Jackstream = 1,
            Chordjack = 1,
            DoubleHandJack = 1,
            Fieldjack = 0.95,
        },
        Dexterity = new()
        {
            Dump = 0.6,
            Singlestream = 1,
            Chord = 1,
            Speed = 0.96,
            Trill = 0.92,
        },
        Stamina = new()
        {
            LongBurst = 1,
            SingleHandTrill = 1,
        },
        Tech = new()
        {
            Flam = 0.9,
            PatternTypeSwitch = 1,
            RhythmicalIrregularity = 1,
        },
        LN = new()
        {
            LNShield = 0.5,
            Inverse = 0.7,
            RiceLN = 0.2,
            RiceMix = 0.65,
            Shield = 0.8,
        },
        SV = new()
        {
            Fast = 1,
            Slow = 0.9,
            Stutter = 0.85,
            Burst = 1,
            ParsingDensity = 1,
        },
    };

    public static readonly AnalyzedDifficulty InstabilityWeights = new()
    {
        Jack = new()
        {
            Minijack = 1,
            Anchor = 0.2,
            Jackstream = 0.3,
            Chordjack = 0.4,
            DoubleHandJack = 0.75,
            Fieldjack = 0.3,
        },
        Dexterity = new()
        {
            Dump = 0.2,
            Singlestream = 0.85,
            Chord = 0.25,
            Speed = 0.64,
            Trill = 0.8,
        },
        Stamina = new()
        {
            LongBurst = 0.35,
            SingleHandTrill = 0.9,
        },
        Tech = new()
        {
            Flam = 0.85,
            PatternTypeSwitch = 1,
            RhythmicalIrregularity = 1,
        },
        LN = new()
        {
            LNShield = 0.3,
            Inverse = 0.2,
            RiceLN = 0.4,
            RiceMix = 0.15,
            Shield = 0.25,
        },
        SV = new()
        {
            Fast = 0.6,
            Slow = 0.8,
            Stutter = 0.7,
            Burst = 1,
            ParsingDensity = 0.1,
        },
    };
}
