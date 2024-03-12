﻿namespace OsuRealDifficulty.Mania;

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
        AddWeightedLongNotes(difficulty.LongNotes, weights.LongNotes);
        AddWeightedScrolling(difficulty.Scrolling, weights.Scrolling);

        NormalizeValue(ref overall.Overall);
        return overall;

        void AddWeightedDexterity(
            AnalyzedDifficulty.DexterityRate difficulty,
            AnalyzedDifficulty.DexterityRate weights)
        {
            ref double segmentSum = ref overall.Dexterity;
            AddWeighted(difficulty.Speed, weights.Speed, ref segmentSum);
            AddWeighted(difficulty.Chord, weights.Chord, ref segmentSum);
            AddWeighted(difficulty.Dump, weights.Dump, ref segmentSum);
            AddWeighted(difficulty.Trill, weights.Trill, ref segmentSum);
            AddWeighted(difficulty.ChordGap, weights.ChordGap, ref segmentSum);
            AddWeighted(difficulty.Singlestream, weights.Singlestream, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedJack(
            AnalyzedDifficulty.JackRate difficulty,
            AnalyzedDifficulty.JackRate weights)
        {
            ref double segmentSum = ref overall.Jack;
            AddWeighted(difficulty.Minijack, weights.Minijack, ref segmentSum);
            AddWeighted(difficulty.Chordjack, weights.Chordjack, ref segmentSum);
            AddWeighted(difficulty.Anchor, weights.Anchor, ref segmentSum);
            AddWeighted(difficulty.Jackstream, weights.Jackstream, ref segmentSum);
            AddWeighted(difficulty.Fieldjack, weights.Fieldjack, ref segmentSum);
            AddWeighted(difficulty.DoubleHandJack, weights.DoubleHandJack, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedTech(
            AnalyzedDifficulty.TechRate difficulty,
            AnalyzedDifficulty.TechRate weights)
        {
            ref double segmentSum = ref overall.Tech;
            AddWeighted(difficulty.PatternSwitch, weights.PatternSwitch, ref segmentSum);
            AddWeighted(difficulty.RhythmIrregularity, weights.RhythmIrregularity, ref segmentSum);
            AddWeighted(difficulty.Flam, weights.Flam, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedStamina(
            AnalyzedDifficulty.StaminaRate difficulty,
            AnalyzedDifficulty.StaminaRate weights)
        {
            ref double segmentSum = ref overall.Stamina;
            AddWeighted(difficulty.LongBurst, weights.LongBurst, ref segmentSum);
            AddWeighted(difficulty.SteadyRateStream, weights.SteadyRateStream, ref segmentSum);
            AddWeighted(difficulty.SingleHandTrill, weights.SingleHandTrill, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedLongNotes(
            AnalyzedDifficulty.LongNotesRate difficulty,
            AnalyzedDifficulty.LongNotesRate weights)
        {
            ref double segmentSum = ref overall.LongNotes;
            AddWeighted(difficulty.RiceMix, weights.RiceMix, ref segmentSum);
            AddWeighted(difficulty.RiceLN, weights.RiceLN, ref segmentSum);
            AddWeighted(difficulty.Inverse, weights.Inverse, ref segmentSum);
            AddWeighted(difficulty.Shield, weights.Shield, ref segmentSum);
            AddWeighted(difficulty.LNShield, weights.LNShield, ref segmentSum);
            NormalizeValue(ref segmentSum);
        }
        void AddWeightedScrolling(
            AnalyzedDifficulty.ScrollingRate difficulty,
            AnalyzedDifficulty.ScrollingRate weights)
        {
            ref double segmentSum = ref overall.Scrolling;
            AddWeighted(difficulty.Slow, weights.Slow, ref segmentSum);
            AddWeighted(difficulty.Fast, weights.Fast, ref segmentSum);
            AddWeighted(difficulty.Burst, weights.Burst, ref segmentSum);
            AddWeighted(difficulty.Stutter, weights.Stutter, ref segmentSum);
            AddWeighted(difficulty.VisualDensity, weights.VisualDensity, ref segmentSum);
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

        static void NormalizeValue(ref double value)
        {
            value = AnalyzedDifficultyFacts.NormalizeValue(value);
        }
    }
}
