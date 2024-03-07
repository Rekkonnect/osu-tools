namespace OsuRealDifficulty.Mania;

public class AnalyzedDifficulty
{
    public static AnalyzedDifficulty NewPending => new()
    {
        Jack = new()
        {
            Minijack = CalculationResult.Pending,
            Anchor = CalculationResult.Pending,
            Jackstream = CalculationResult.Pending,
            Chordjack = CalculationResult.Pending,
            DoubleHandJack = CalculationResult.Pending,
            Fieldjack = CalculationResult.Pending,
        },
        Dexterity = new()
        {
            Dump = CalculationResult.Pending,
            Singlestream = CalculationResult.Pending,
            Chord = CalculationResult.Pending,
            Speed = CalculationResult.Pending,
            Trill = CalculationResult.Pending,
        },
        Stamina = new()
        {
            LongBurst = CalculationResult.Pending,
            SingleHandTrill = CalculationResult.Pending,
        },
        Tech = new()
        {
            Flam = CalculationResult.Pending,
            PatternTypeSwitch = CalculationResult.Pending,
            RhythmicalIrregularity = CalculationResult.Pending,
        },
        LN = new()
        {
            LNShield = CalculationResult.Pending,
            Inverse = CalculationResult.Pending,
            RiceLN = CalculationResult.Pending,
            RiceMix = CalculationResult.Pending,
            Shield = CalculationResult.Pending,
        },
        SV = new()
        {
            Fast = CalculationResult.Pending,
            Slow = CalculationResult.Pending,
            Stutter = CalculationResult.Pending,
            Burst = CalculationResult.Pending,
            ParsingDensity = CalculationResult.Pending,
        },
    };

    public required DexterityRate Dexterity;
    public required TechRate Tech;
    public required JackRate Jack;
    public required StaminaRate Stamina;
    public required LNRate LN;
    public required SVRate SV;

    public struct DexterityRate
    {
        /// <summary>
        /// The logarithmic mean of the speed of each chord registration.
        /// </summary>
        public required CalculationResult Speed;
        /// <summary>
        /// The impact of multi-note chords.
        /// </summary>
        public required CalculationResult Chord;
        /// <summary>
        /// The speed of the trills being played.
        /// </summary>
        /// <remarks>
        /// This does not account for the hands that are used during the trill.
        /// <br/>
        /// <seealso cref="StaminaRate.SingleHandTrill"/> measures this skill.
        /// </remarks>
        public required CalculationResult Trill;
        /// <summary>
        /// The occurrence of dump-like patterns.
        /// </summary>
        public required CalculationResult Dump;
        /// <summary>
        /// The occurrence of quick singlestream chords.
        /// </summary>
        public required CalculationResult Singlestream;
    }

    public struct TechRate
    {
        /// <summary>
        /// Rhythmical irregularities involve switching between rhythmical patterns
        /// like 1/4 into 1/3 into 1/12, etc. Denominators with common divisors are
        /// weighted less. Higher adjustment ratios are weighted heavier.
        /// </summary>
        public required CalculationResult RhythmicalIrregularity;
        /// <summary>
        /// Pattern type switching scans for lack of continuity of an occurring pattern
        /// and the mix of skills that are required.
        /// </summary>
        public required CalculationResult PatternTypeSwitch;
        /// <summary>
        /// Flams count as non-jack notes that are very close to each other but not
        /// in the same chord.
        /// </summary>
        public required CalculationResult Flam;
    }

    public struct JackRate
    {
        /*
         * |   -|
         * |  - |
         * | -  |
         * |--  |
         *   ^ minijack
         */
        /// <summary>
        /// Minijacks are two-chord jacks of the same fingers.
        /// </summary>
        /// <remarks>
        /// Repeated jacks involving different finger chords are measured
        /// by <seealso cref="Jackstream"/>.
        /// </remarks>
        public required CalculationResult Minijack;

        /*
         * | - -|
         * | -- |
         * | -  |
         * |--  |
         *   ^ anchor
         */
        /// <summary>
        /// Anchors are 3+-chord jacks of the same fingers.
        /// </summary>
        /// <remarks>
        /// Repeated jacks involving different finger chords are measured
        /// by <seealso cref="Jackstream"/>.
        /// </remarks>
        public required CalculationResult Anchor;

        /*
         * |  --|
         * |  - |
         * | -  |
         * |--  |
         *   ^ jackstream
         */
        /// <summary>
        /// Jackstreams involve jacks of multiple fingers that are possibly
        /// alternating.
        /// </summary>
        public required CalculationResult Jackstream;

        /*
         * |--- |
         * |  --|
         * |-- -|
         * |--- |
         *  ^^ chordjack
         */
        /// <summary>
        /// Chordjacks are jacks involving multiple fingers per jack instance
        /// that are possibly alternating.
        /// </summary>
        /// <remarks>
        /// <seealso cref="Jackstream"/> also includes chordjacks.
        /// </remarks>
        public required CalculationResult Chordjack;

        /*
         * |- - |
         * | -  |
         * |- --|
         * |-- -|
         *  ^  ^ double hand jack
         */
        /// <summary>
        /// Double hand jack involves jacks that require jacking both hands.
        /// </summary>
        /// <remarks>
        /// Both <seealso cref="Jackstream"/> and <seealso cref="Chordjack"/>
        /// also include double hand jacks.
        /// </remarks>
        public required CalculationResult DoubleHandJack;

        /*
         * |  - |
         * |----| < fieldjack
         * |- --|
         * |----| < fieldjack
         * 
         * |     - |
         * |-------| < fieldjack
         * |   -   |
         * |-------| < fieldjack-ish
         * |    -  |
         * NOTE: 7K is rewritten into 8K with alternating hand presses
         * Occupying all columns in the same chord is a field press, regardless
         * of the rewriting. If the preceding or the succeeding notes occupy the same
         * finger, it is a fieldjack.
         * In the above example, both are fieldjacks due to the next notes being
         * in non-special columns. In the example below, these are not fieldjacks:
         * 
         * |   -   |
         * |-------| < NOT fieldjack
         * |   -   |
         * |-------| < NOT fieldjack
         * |   -   |
         * 
         * The rewrite interprets this section as:
         * 
         * |   -    |
         * |--- ----|
         * |   -    |
         * |--- ----|
         * |   -    |
         */
        /// <summary>
        /// Fieldjacks involve pressing all the columns in any stream
        /// section, where any notes next to the fieldjack would be considered
        /// as a jack.
        /// </summary>
        /// <remarks>
        /// Both <seealso cref="Jackstream"/> and <seealso cref="Chordjack"/>
        /// also include fieldjacks.
        /// </remarks>
        public required CalculationResult Fieldjack;
    }

    public struct StaminaRate
    {
        /// <summary>
        /// Single-hand trills are trill patterns that occur with the usage of the same
        /// hand for both notes involved in the trill.
        /// </summary>
        /// <remarks>
        /// <seealso cref="DexterityRate.Trill"/> also includes single-hand trills.
        /// </remarks>
        public required CalculationResult SingleHandTrill;
        /// <summary>
        /// Represents the longer difficulty spikes present in the map w.r.t. chord
        /// density, disregarding the individual patterns.
        /// </summary>
        public required CalculationResult LongBurst;
    }

    public struct LNRate
    {
        /// <summary>
        /// Measures the rice-like LNs when using cut LN skins.
        /// </summary>
        public required CalculationResult RiceLN;
        /// <summary>
        /// Measures the inverse LN patterns that involve independently controlling the
        /// held fingers.
        /// </summary>
        public required CalculationResult Inverse;
        /// <summary>
        /// Measures the mix of rice patterns while holding LNs.
        /// </summary>
        public required CalculationResult RiceMix;
        /// <summary>
        /// Measures the pattern of rice into LN in quick succession.
        /// </summary>
        public required CalculationResult Shield;
        /// <summary>
        /// Measures the pattern of LN release into LN start in quick succession.
        /// </summary>
        public required CalculationResult LNShield;
    }

    public struct SVRate
    {
        /// <summary>
        /// Reflects the burst of SVs that occur in a time window.
        /// </summary>
        public required CalculationResult Burst;
        /// <summary>
        /// Reflects the stuttering effects that occur from a combination of SVs.
        /// </summary>
        public required CalculationResult Stutter;
        /// <summary>
        /// Reflects the slower scrolling speed's effect on the playfield.
        /// </summary>
        public required CalculationResult Slow;
        /// <summary>
        /// Reflects the faster scrolling speed's effect on the playfield.
        /// </summary>
        public required CalculationResult Fast;
        /// <summary>
        /// Determines the parsing density, as represented from the visible notes
        /// per screen view. This is dynamically calculated based on the visual
        /// position of the notes according to the SVs at each section.
        /// </summary>
        public required CalculationResult ParsingDensity;
    }
}
