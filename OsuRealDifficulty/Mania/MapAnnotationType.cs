namespace OsuRealDifficulty.Mania;

#region

public enum MapAnnotationType
{
    Void = 0,

    // Dexterity
    Chord,
    Trill,
    Dump,
    Singlestream,
    ChordGap,
    ChordGapPattern,

    // Tech
    RhythmicalIrregularity,
    PatternTypeSwitch,
    Flam,

    // Jack
    Minijack,
    Anchor,
    Jackstream,
    Chordjack,
    DoubleHandJack,
    Fieldjack,

    // Stamina
    SingleHandTrill,

    // LN
    RiceLN,
    Inverse,
    RiceMix,
    Shield,
    LNShield,

    // SV
    SVBurst,
    Stutter,
    Slow,
    Fast,
    ParsingDensity,
}

#endregion
