using OsuRealDifficulty.UI.WinForms.Core;
using OsuRealDifficulty.UI.WinForms.Logging;
using OsuRealDifficulty.UI.WinForms.Utilities;

namespace OsuRealDifficulty.UI.WinForms;

public partial class LogViewForm : Form
{
    // retrieving the log string from the control's Text property
    // allocates a brand new string, which we don't want
    private string _displayedLogString = string.Empty;

    private readonly CancellationTokenSource _loopTaskTokenSource = new();

    public LogViewForm()
    {
        InitializeComponent();
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);

        RefreshLog();
        var token = _loopTaskTokenSource.Token;
        LoopingTask.Begin(500, InvokeRefreshLog, token);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _loopTaskTokenSource.Cancel();
        base.OnFormClosing(e);
    }

    private void openLogFolderButton_Click(object sender, EventArgs e)
    {
        OpenLogs();
    }

    private void clearLogViewButton_Click(object sender, EventArgs e)
    {
        ClearLogs();
    }

    private void ClearLogs()
    {
        InMemoryStringSink.Instance.Clear();
        RefreshLog();
    }

    private void OpenLogs()
    {
        Task.Run(OpenLogsCore);
    }

    private void OpenLogsCore()
    {
        FileExplorerUtilitiesEx.StartExplorerAtRelativeRoot("logs");
    }

    private void RefreshLog()
    {
        var newLogString = InMemoryStringSink.Instance.LogString;
        if (newLogString == _displayedLogString)
            return;

        _displayedLogString = newLogString;
        contentTextBox.SetTextScrollToEnd(newLogString);
    }

    private void InvokeRefreshLog()
    {
        Invoke(RefreshLog);
    }
}
