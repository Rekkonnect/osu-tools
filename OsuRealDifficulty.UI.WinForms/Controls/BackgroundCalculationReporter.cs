using OsuRealDifficulty.UI.WinForms.Core;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public partial class BackgroundCalculationReporter : UserControl
{
    private const string _backgroundCalculationRunningMessage =
        """
        calculating all beatmaps'
        difficulty in background
        """;
    private const string _backgroundCalculationFinishedMessage =
        """
        finished calculation
        for all beatmaps
        """;

    // use a new empty to avoid caring about nulls
    private BackgroundCalculationInformation _information = new();
    private bool _pendingInvalidationHandling = false;

    public BackgroundCalculationReporter()
    {
        InitializeComponent();
    }

    public void BindToBackgroundCalculationInformation(
        BackgroundCalculationInformation information)
    {
        _information.InitiationChanged -= TriggerInitiationChange;
        information.InitiationChanged += TriggerInitiationChange;
        _information = information;
        ForceInvalidate();
    }

    private void TriggerInitiationChange(BackgroundCalculationInformation information)
    {
        Task.Run(HandleRefreshAsync);
    }

    private async Task HandleRefreshAsync()
    {
        while (_information.IsRunning)
        {
            Invoke(ForceInvalidate);
            await Task.Delay(42);
        }
        Invoke(ForceInvalidate);
    }

    private void ForceInvalidate()
    {
        _pendingInvalidationHandling = true;
        Invalidate();
    }

    protected override void OnInvalidated(InvalidateEventArgs e)
    {
        RefreshDisplay();
        base.OnInvalidated(e);
    }

    private void RefreshDisplay()
    {
        if (!_pendingInvalidationHandling)
            return;

        _pendingInvalidationHandling = false;

        Visible = _information.TotalBeatmaps > 0;

        backgroundCalculationInformationLabel.Text = GetTextForRunningState(_information);

        backgroundCalculationProgressLabel.Text =
            $"{_information.ProcessedBeatmaps} / {_information.TotalBeatmaps}";

        backgroundCalculationProgressBar.Maximum = _information.TotalBeatmaps;
        backgroundCalculationProgressBar.Value = _information.ProcessedBeatmaps;

        executionTimeLabel.Text = $"{_information.EffectiveExecutionTime.TotalSeconds:N2}s";
    }

    private static string GetTextForRunningState(
        BackgroundCalculationInformation information)
    {
        return information.IsRunning
            ? _backgroundCalculationRunningMessage
            : _backgroundCalculationFinishedMessage;
    }
}
