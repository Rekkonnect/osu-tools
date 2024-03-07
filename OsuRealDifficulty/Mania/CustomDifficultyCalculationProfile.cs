namespace OsuRealDifficulty.Mania;

public class CustomDifficultyCalculationProfile(
    AnalyzedDifficulty starWeights, AnalyzedDifficulty instabilityWeights)
    : DifficultyCalculationProfile
{
    public override EstimatedDifficultyStats Calculate(AnalyzedDifficulty difficulty)
    {
        return new(
            CalculateStarRating(difficulty),
            CalculateInstabilityRating(difficulty));
    }

    private SegmentedOverallDifficulty CalculateStarRating(AnalyzedDifficulty difficulty)
    {
        return CalculateWeights(difficulty, starWeights);
    }
    private double CalculateInstabilityRating(AnalyzedDifficulty difficulty)
    {
        return CalculateWeights(difficulty, instabilityWeights).Overall * 20;
    }

    private static SegmentedOverallDifficulty CalculateWeights(
        AnalyzedDifficulty difficulty,
        AnalyzedDifficulty weights)
    {
        var overall = new SegmentedOverallDifficulty();

        AddWeightedDexterity(difficulty.Dexterity, weights.Dexterity);
        AddWeightedJack(difficulty.Jack, weights.Jack);
        AddWeightedTech(difficulty.Tech, weights.Tech);
        AddWeightedStamina(difficulty.Stamina, weights.Stamina);
        AddWeightedLN(difficulty.LN, weights.LN);
        AddWeightedSV(difficulty.SV, weights.SV);

        NormalizeValue(ref overall.Overall);
        return overall;

        void AddWeightedDexterity(
            AnalyzedDifficulty.DexterityRate difficulty,
            AnalyzedDifficulty.DexterityRate weights)
        {
            ref double segmentSum = ref overall.Dexterity;
            AddWeighted(difficulty.Speed, weights.Speed, ref segmentSum);
            AddWeighted(difficulty.Singlestream, weights.Singlestream, ref segmentSum);
            AddWeighted(difficulty.Chord, weights.Chord, ref segmentSum);
            AddWeighted(difficulty.Dump, weights.Dump, ref segmentSum);
            AddWeighted(difficulty.Trill, weights.Trill, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedJack(
            AnalyzedDifficulty.JackRate difficulty,
            AnalyzedDifficulty.JackRate weights)
        {
            ref double segmentSum = ref overall.Jack;
            AddWeighted(difficulty.Fieldjack, weights.Fieldjack, ref segmentSum);
            AddWeighted(difficulty.Jackstream, weights.Jackstream, ref segmentSum);
            AddWeighted(difficulty.Chordjack, weights.Chordjack, ref segmentSum);
            AddWeighted(difficulty.DoubleHandJack, weights.DoubleHandJack, ref segmentSum);
            AddWeighted(difficulty.Minijack, weights.Minijack, ref segmentSum);
            AddWeighted(difficulty.Anchor, weights.Anchor, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedTech(
            AnalyzedDifficulty.TechRate difficulty,
            AnalyzedDifficulty.TechRate weights)
        {
            ref double segmentSum = ref overall.Tech;
            AddWeighted(difficulty.Flam, weights.Flam, ref segmentSum);
            AddWeighted(difficulty.PatternTypeSwitch, weights.PatternTypeSwitch, ref segmentSum);
            AddWeighted(difficulty.RhythmicalIrregularity, weights.RhythmicalIrregularity, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedStamina(
            AnalyzedDifficulty.StaminaRate difficulty,
            AnalyzedDifficulty.StaminaRate weights)
        {
            ref double segmentSum = ref overall.Stamina;
            AddWeighted(difficulty.LongBurst, weights.LongBurst, ref segmentSum);
            AddWeighted(difficulty.SingleHandTrill, weights.SingleHandTrill, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedLN(
            AnalyzedDifficulty.LNRate difficulty,
            AnalyzedDifficulty.LNRate weights)
        {
            ref double segmentSum = ref overall.LN;
            AddWeighted(difficulty.LNShield, weights.LNShield, ref segmentSum);
            AddWeighted(difficulty.RiceLN, weights.RiceLN, ref segmentSum);
            AddWeighted(difficulty.RiceMix, weights.RiceMix, ref segmentSum);
            AddWeighted(difficulty.Shield, weights.Shield, ref segmentSum);
            AddWeighted(difficulty.Inverse, weights.Inverse, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedSV(
            AnalyzedDifficulty.SVRate difficulty,
            AnalyzedDifficulty.SVRate weights)
        {
            ref double segmentSum = ref overall.SV;
            AddWeighted(difficulty.Slow, weights.Slow, ref segmentSum);
            AddWeighted(difficulty.Fast, weights.Fast, ref segmentSum);
            AddWeighted(difficulty.Stutter, weights.Stutter, ref segmentSum);
            AddWeighted(difficulty.ParsingDensity, weights.ParsingDensity, ref segmentSum);
            AddWeighted(difficulty.Burst, weights.Burst, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }

        void AddWeighted(double value, double weight, ref double segmentSum)
        {
            // TODO: Test applying the weight after the powering of the value
            var weightedValue = value * weight;
            var poweredValue = AnalyzedDifficultyFacts.AbsoluteValue(weightedValue);
            overall.Overall += poweredValue;
            segmentSum += poweredValue;
        }

        void NormalizeValue(ref double value)
        {
            value = AnalyzedDifficultyFacts.NormalizeValue(value);
        }
    }
}
