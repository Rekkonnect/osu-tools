using OsuParsers.Database.Objects;
using OsuRealDifficulty.Mania;
using OsuRealDifficulty.UI.WinForms.Utilities;
using Serilog;
using System.ComponentModel;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public partial class AnalysisResultDisplay : UserControl
{
    private bool _pendingRefreshDisplay = false;

    private CancellableTask? _refreshListenTask = null;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public AnalyzedDifficulty AnalyzedDifficulty
        => DifficultyCalculationResult.AnalyzedDifficulty;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public FullDifficultyCalculationResult DifficultyCalculationResult { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DbBeatmap? SelectedBeatmap { get; set; }

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

        // initialize a pending full result before the definite assignment
        DifficultyCalculationResult = FullDifficultyCalculationResult.NewPending;

        if (!DesignMode)
        {
            RefreshDisplay();
        }

        BringWarningLabelToFront();
    }

    private void BringWarningLabelToFront()
    {
        // we don't want the label to hide the groups under it in
        // design mode

        // and this design choice was made to avoid manually toggling
        // the visibility of all the other groups, which is susceptible
        // to flickering
        if (DesignMode)
            return;

        warningLabel.BringToFront();
    }

    public void RefreshDisplay(FullDifficultyCalculationResult? newResult)
    {
        if (newResult is not null)
        {
            DifficultyCalculationResult = newResult;
        }
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        _pendingRefreshDisplay = true;
        Invalidate();
    }

    private void PerformRefreshDisplay()
    {
        using var _ = this.LayoutSuspension();
        RefreshAnalysisDisplay();
        RefreshBeatmapSelection();
    }

    protected override void OnInvalidated(InvalidateEventArgs e)
    {
        HandlePendingInvalidatedEvents();
        base.OnInvalidated(e);
    }

    private void HandlePendingInvalidatedEvents()
    {
        if (_pendingRefreshDisplay)
        {
            _pendingRefreshDisplay = false;
            PerformRefreshDisplay();
        }
    }

    private void RefreshBeatmapSelection()
    {
        var hasBeatmap = SelectedBeatmap is not null;
        warningLabel.Visible = !hasBeatmap;
    }

    private void RefreshAnalysisDisplay()
    {
        var hasBeatmap = SelectedBeatmap is not null;
        // do not refresh the display if there is no beatmap
        if (!hasBeatmap)
            return;

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

        var stats = DifficultyCalculationResult.Overview;
        RefreshOverviewDisplays(stats);
    }

    private void RefreshOverviewDisplays(DifficultyStatsOverview stats)
    {
        var segmented = stats.OverallDifficulty;

        dexterityCategoryLabel.CalculationResult = segmented.Dexterity;
        jackCategoryLabel.CalculationResult = segmented.Jack;
        techCategoryLabel.CalculationResult = segmented.Tech;
        staminaCategoryLabel.CalculationResult = segmented.Stamina;
        longNotesCategoryLabel.CalculationResult = segmented.LongNotes;
        scrollingCategoryLabel.CalculationResult = segmented.Scrolling;

        overallLabel.CalculationResult = segmented.Overall;
        instabilityLabel.CalculationResult = stats.InstabilityRate;
    }

    private static CalculationResult ConditionallyInvalid(
        double result,
        bool valid,
        double invalidResult = CalculationResult.Pending)
    {
        return valid ? result : invalidResult;
    }

    public void BeginListeningForRequests(
        RefreshRequestChannel requestChannel,
        CancellationTokenSource cancellationTokenSource)
    {
        var task = ListenAsync(requestChannel, cancellationTokenSource.Token);
        _refreshListenTask = new(task, cancellationTokenSource);
    }

    public void StopListeningForRequests()
    {
        if (_refreshListenTask is null)
        {
            return;
        }

        try
        {
            // This might throw after being disposed the moment the calculation is over
            _refreshListenTask.CancellationTokenSource.Cancel();
        }
        catch (OperationCanceledException cancellation)
        {
            Log.Logger.Information(
                cancellation,
                $"{nameof(StopListeningForRequests)} caught a cancellation");
        }
        catch (Exception ex)
        {
            Log.Logger.Error(
                ex,
                $"{nameof(StopListeningForRequests)} caught a non-cancellation exception");
        }
        finally
        {
            _refreshListenTask = null;
        }
    }

    private async Task ListenAsync(
        RefreshRequestChannel requestChannel,
        CancellationToken cancellationToken = default)
    {
        while (true)
        {
            const int refreshesPerSecond = 20;
            await requestChannel.ConsumeAllRequests(cancellationToken);
            await Task.Delay(1000 / refreshesPerSecond, cancellationToken);
        }
    }
}
