using OsuRealDifficulty.Mania;
using System.ComponentModel;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public partial class AnalysisResultDisplay : UserControl
{
    private DifficultyCalculationProfile _calculationProfile;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public AnalyzedDifficulty AnalyzedDifficulty { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DifficultyCalculationProfile CalculationProfile
    {
        get
        {
            return _calculationProfile;
        }
        set
        {
            _calculationProfile = value;
            RefreshDisplay();
        }
    }

    public string Caption
    {
        get
        {
            return outerGroupBox.Text;
        }
        set
        {
            outerGroupBox.Text = value;
        }
    }

    public AnalysisResultDisplay()
    {
        InitializeComponent();

        // Initialize a default profile and a pending analyzed difficulty
        // before the definite assignment
        AnalyzedDifficulty = AnalyzedDifficulty.NewPending;
        var pending = AnalyzedDifficulty.NewPending;
        _calculationProfile = new CustomDifficultyCalculationProfile(pending, pending);

        if (!DesignMode)
        {
            CalculationProfile = _calculationProfile;
        }
    }

    public void RefreshDisplay()
    {
        var difficulty = AnalyzedDifficulty;

        // dexterity
        speedLabel.CalculationResult = difficulty.Dexterity.Speed;
        chordLabel.CalculationResult = difficulty.Dexterity.Chord;
        dumpLabel.CalculationResult = difficulty.Dexterity.Dump;
        trillLabel.CalculationResult = difficulty.Dexterity.Trill;
        chordGapLabel.CalculationResult = difficulty.Dexterity.ChordGap;
        singlestreamLabel.CalculationResult = difficulty.Dexterity.Singlestream;

        // jack
        minijackLabel.CalculationResult = difficulty.Jack.Minijack;
        chordjackLabel.CalculationResult = difficulty.Jack.Chordjack;
        anchorLabel.CalculationResult = difficulty.Jack.Anchor;
        jackstreamLabel.CalculationResult = difficulty.Jack.Jackstream;
        fieldjackLabel.CalculationResult = difficulty.Jack.Fieldjack;
        doubleHandJackLabel.CalculationResult = difficulty.Jack.DoubleHandJack;

        // tech
        patternSwitchLabel.CalculationResult = difficulty.Tech.PatternSwitch;
        rhythmIrregularityLabel.CalculationResult = difficulty.Tech.RhythmIrregularity;
        flamLabel.CalculationResult = difficulty.Tech.Flam;

        // stamina
        longBurstLabel.CalculationResult = difficulty.Stamina.LongBurst;
        steadyRateStreamLabel.CalculationResult = difficulty.Stamina.SteadyRateStream;
        singleHandTrillLabel.CalculationResult = difficulty.Stamina.SingleHandTrill;

        // stamina
        riceMixLabel.CalculationResult = difficulty.LongNotes.RiceMix;
        riceLnLabel.CalculationResult = difficulty.LongNotes.RiceLN;
        inverseLabel.CalculationResult = difficulty.LongNotes.Inverse;
        shieldLabel.CalculationResult = difficulty.LongNotes.Shield;
        lnShieldLabel.CalculationResult = difficulty.LongNotes.LNShield;

        // scrolling
        slowLabel.CalculationResult = difficulty.Scrolling.Slow;
        fastLabel.CalculationResult = difficulty.Scrolling.Fast;
        burstLabel.CalculationResult = difficulty.Scrolling.Burst;
        stutterLabel.CalculationResult = difficulty.Scrolling.Stutter;
        visualDensityLabel.CalculationResult = difficulty.Scrolling.VisualDensity;

        var stats = CalculationProfile.Calculate(difficulty);
        RefreshOverallDisplays(stats);
    }

    private void RefreshOverallDisplays(EstimatedDifficultyStats stats)
    {
        var difficulty = AnalyzedDifficulty;
        var segmented = stats.OverallDifficulty;

        dexterityCategoryLabel.CalculationResult = ConditionallyInvalid(
            segmented.Dexterity,
            difficulty.Dexterity.AreAllValid);

        jackCategoryLabel.CalculationResult = ConditionallyInvalid(
            segmented.Jack,
            difficulty.Jack.AreAllValid);

        techCategoryLabel.CalculationResult = ConditionallyInvalid(
            segmented.Tech,
            difficulty.Tech.AreAllValid);

        staminaCategoryLabel.CalculationResult = ConditionallyInvalid(
            segmented.Stamina,
            difficulty.Stamina.AreAllValid);

        longNotesCategoryLabel.CalculationResult = ConditionallyInvalid(
            segmented.LongNotes,
            difficulty.LongNotes.AreAllValid);

        scrollingCategoryLabel.CalculationResult = ConditionallyInvalid(
            segmented.Scrolling,
            difficulty.Scrolling.AreAllValid);

        var allValid = difficulty.AreAllValid;
        // This currently displays "..." regardless of whether the results are actually
        // pending, or another error has occurred
        overallLabel.CalculationResult = ConditionallyInvalid(
            segmented.Overall,
            allValid);

        instabilityLabel.CalculationResult = ConditionallyInvalid(
            stats.InstabilityRate,
            allValid);
    }

    private static CalculationResult ConditionallyInvalid(
        double result,
        bool valid,
        double invalidResult = CalculationResult.Pending)
    {
        return valid ? result : invalidResult;
    }
}
