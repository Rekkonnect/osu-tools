namespace OsuRealDifficulty.Mania;

public class AnalyzedDifficulty
{
    public static AnalyzedDifficulty NewPending => new()
    {
        Dexterity = new()
        {
            Speed = CalculationResult.Pending,
            Chord = CalculationResult.Pending,
            Dump = CalculationResult.Pending,
            Trill = CalculationResult.Pending,
            ChordGap = CalculationResult.Pending,
            Singlestream = CalculationResult.Pending,
        },
        Jack = new()
        {
            Minijack = CalculationResult.Pending,
            Chordjack = CalculationResult.Pending,
            Anchor = CalculationResult.Pending,
            Jackstream = CalculationResult.Pending,
            Fieldjack = CalculationResult.Pending,
            DoubleHandJack = CalculationResult.Pending,
        },
        Tech = new()
        {
            PatternSwitch = CalculationResult.Pending,
            RhythmIrregularity = CalculationResult.Pending,
            Flam = CalculationResult.Pending,
        },
        Stamina = new()
        {
            LongBurst = CalculationResult.Pending,
            SteadyRateStream = CalculationResult.Pending,
            SingleHandTrill = CalculationResult.Pending,
        },
        LongNotes = new()
        {
            RiceMix = CalculationResult.Pending,
            RiceLN = CalculationResult.Pending,
            Inverse = CalculationResult.Pending,
            Shield = CalculationResult.Pending,
            LNShield = CalculationResult.Pending,
        },
        Scrolling = new()
        {
            Slow = CalculationResult.Pending,
            Fast = CalculationResult.Pending,
            Burst = CalculationResult.Pending,
            Stutter = CalculationResult.Pending,
            VisualDensity = CalculationResult.Pending,
        },
    };

    public required DexterityRate Dexterity;
    public required JackRate Jack;
    public required TechRate Tech;
    public required StaminaRate Stamina;
    public required LongNotesRate LongNotes;
    public required ScrollingRate Scrolling;

    public bool AreAllValid
        => Dexterity.AreAllValid
        && Jack.AreAllValid
        && Tech.AreAllValid
        && Stamina.AreAllValid
        && LongNotes.AreAllValid
        && Scrolling.AreAllValid
        ;

    public interface IDifficultyRate
    {
        public bool AreAllValid => GetResultValidity(out _);
        public bool GetResultValidity(out CalculationResult erroneousResult);

        public static bool GetResultValidity(
            Span<CalculationResult> results,
            out CalculationResult calculationResult)
        {
            calculationResult = 0;

            for (int i = 0; i < results.Length; i++)
            {
                var result = results[i];
                calculationResult = GetMoreImportantInvalid(result, calculationResult);
            }

            return calculationResult.IsValid;
        }

        private static CalculationResult GetMoreImportantInvalid(
            CalculationResult a, CalculationResult b)
        {
            if (a.IsError || b.IsError)
                return CalculationResult.Error;

            if (a.IsCancelled || b.IsCancelled)
                return CalculationResult.Cancelled;

            if (a.IsUnknown || b.IsUnknown)
                return CalculationResult.Unknown;

            if (a.IsPending || b.IsPending)
                return CalculationResult.Pending;

            // Placeholder value
            return a;
        }
    }

    public struct DexterityRate : IDifficultyRate
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
        /// The occurrence of dump-like patterns.
        /// </summary>
        public required CalculationResult Dump;
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
        /// The occurrence and impact of gaps in the notes between chords and
        /// the gaps that are formed between chords.
        /// </summary>
        public required CalculationResult ChordGap;
        /// <summary>
        /// The occurrence of quick singlestream chords.
        /// </summary>
        public required CalculationResult Singlestream;

        public readonly bool AreAllValid
            => Speed.IsValid
            && Chord.IsValid
            && Dump.IsValid
            && Trill.IsValid
            && ChordGap.IsValid
            && Singlestream.IsValid
            ;

        public readonly bool GetResultValidity(out CalculationResult erroneousResult)
        {
            return IDifficultyRate.GetResultValidity(
                [
                    Speed,
                    Chord,
                    Dump,
                    Trill,
                    ChordGap,
                    Singlestream,
                ],
                out erroneousResult);
        }
    }

    public struct JackRate : IDifficultyRate
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

        public readonly bool AreAllValid
            => Minijack.IsValid
            && Chordjack.IsValid
            && Anchor.IsValid
            && Jackstream.IsValid
            && Fieldjack.IsValid
            && DoubleHandJack.IsValid
            ;

        public readonly bool GetResultValidity(out CalculationResult erroneousResult)
        {
            return IDifficultyRate.GetResultValidity(
                [
                    Minijack,
                    Chordjack,
                    Anchor,
                    Jackstream,
                    Fieldjack,
                    DoubleHandJack,
                ],
                out erroneousResult);
        }
    }

    public struct TechRate : IDifficultyRate
    {
        /// <summary>
        /// Pattern type switching scans for lack of continuity of an occurring pattern
        /// and the mix of skills that are required.
        /// </summary>
        public required CalculationResult PatternSwitch;
        /// <summary>
        /// Rhythmical irregularities involve switching between rhythmical patterns
        /// like 1/4 into 1/3 into 1/12, etc. Denominators with common divisors are
        /// weighted less. Higher adjustment ratios are weighted heavier.
        /// </summary>
        public required CalculationResult RhythmIrregularity;
        /// <summary>
        /// Flams count as non-jack notes that are very close to each other but not
        /// in the same chord.
        /// </summary>
        public required CalculationResult Flam;

        public readonly bool AreAllValid
            => PatternSwitch.IsValid
            && RhythmIrregularity.IsValid
            && Flam.IsValid
            ;

        public readonly bool GetResultValidity(out CalculationResult erroneousResult)
        {
            return IDifficultyRate.GetResultValidity(
                [
                    PatternSwitch,
                    RhythmIrregularity,
                    Flam,
                ],
                out erroneousResult);
        }
    }

    public struct StaminaRate : IDifficultyRate
    {
        /// <summary>
        /// Represents the longer difficulty spikes present in the map w.r.t. chord
        /// density, disregarding the individual patterns.
        /// </summary>
        public required CalculationResult LongBurst;
        /// <summary>
        /// Represents the longer streams whose chords remain equidistant.
        /// </summary>
        public required CalculationResult SteadyRateStream;
        /// <summary>
        /// Single-hand trills are trill patterns that occur with the usage of the same
        /// hand for both notes involved in the trill.
        /// </summary>
        /// <remarks>
        /// <seealso cref="DexterityRate.Trill"/> also includes single-hand trills.
        /// </remarks>
        public required CalculationResult SingleHandTrill;

        public readonly bool AreAllValid
            => LongBurst.IsValid
            && SteadyRateStream.IsValid
            && SingleHandTrill.IsValid
            ;

        public readonly bool GetResultValidity(out CalculationResult erroneousResult)
        {
            return IDifficultyRate.GetResultValidity(
                [
                    LongBurst,
                    SteadyRateStream,
                    SingleHandTrill,
                ],
                out erroneousResult);
        }
    }

    public struct LongNotesRate : IDifficultyRate
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

        public readonly bool AreAllValid
            => RiceMix.IsValid
            && RiceLN.IsValid
            && Inverse.IsValid
            && Shield.IsValid
            && LNShield.IsValid
            ;

        public readonly bool GetResultValidity(out CalculationResult erroneousResult)
        {
            return IDifficultyRate.GetResultValidity(
                [
                    RiceMix,
                    RiceLN,
                    Inverse,
                    Shield,
                    LNShield,
                ],
                out erroneousResult);
        }
    }

    public struct ScrollingRate : IDifficultyRate
    {
        /// <summary>
        /// Reflects the slower scrolling speed's effect on the playfield.
        /// </summary>
        public required CalculationResult Slow;
        /// <summary>
        /// Reflects the faster scrolling speed's effect on the playfield.
        /// </summary>
        public required CalculationResult Fast;
        /// <summary>
        /// Reflects the burst of SVs that occur in a time window.
        /// </summary>
        public required CalculationResult Burst;
        /// <summary>
        /// Reflects the stuttering effects that occur from a combination of SVs.
        /// </summary>
        public required CalculationResult Stutter;
        /// <summary>
        /// Determines the parsing density, as represented from the visible notes
        /// per screen view. This is dynamically calculated based on the visual
        /// position of the notes according to the SVs at each section.
        /// </summary>
        public required CalculationResult VisualDensity;

        public readonly bool AreAllValid
            => Slow.IsValid
            && Fast.IsValid
            && Burst.IsValid
            && Stutter.IsValid
            && VisualDensity.IsValid
            ;

        public readonly bool GetResultValidity(out CalculationResult erroneousResult)
        {
            return IDifficultyRate.GetResultValidity(
                [
                    Slow,
                    Fast,
                    Burst,
                    Stutter,
                    VisualDensity,
                ],
                out erroneousResult);
        }
    }
}
