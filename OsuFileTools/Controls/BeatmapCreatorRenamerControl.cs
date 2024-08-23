using Microsoft.WindowsAPICodePack.Dialogs;
using OsuFileTools.Core;

namespace OsuFileTools.Controls;

public partial class BeatmapCreatorRenamerControl : UserControl
{
    private static readonly Guid _browseDialogCookieIdentifier
        = new("0C34C12D-DA00-4CEF-91A6-65D5D851CDBF");

    public BeatmapCreatorRenamerControl()
    {
        InitializeComponent();
    }

    private void renameButton_Click(object sender, EventArgs e)
    {
        PerformOperation();
    }

    private void PerformOperation()
    {
        var directory = beatmapsDirectoryText.Text;
        if (string.IsNullOrEmpty(directory))
        {
            MessageBox.Show(
                """
                Please select the directory where your beatmaps are stored.
                """,
                "No beatmap directory selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        var directoryInfo = new DirectoryInfo(directory);
        if (!directoryInfo.Exists)
        {
            MessageBox.Show(
                """
                Please select a valid directory.
                """,
                "Invalid beatmap directory selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        Task.Run(() => 
            PerformOperationAsync(directoryInfo)
                .ConfigureAwait(false));
    }

    private async Task PerformOperationAsync(DirectoryInfo directory)
    {
        await Task.Yield();

        Invoke(() => renameButton.Enabled = false);

        var allFiles = directory.GetFiles("*.osu", SearchOption.AllDirectories);

        var options = new BeatmapCreatorRenamer.Options
        {
            Old = oldValueText.Text,
            New = newValueText.Text,
            CreateBackup = generateBackupsCheck.Checked,
        };
        var renamer = new BeatmapCreatorRenamer(options);

        renamer.ProgressOverview.ExpectedTotal = allFiles.Length;

        var cancellationTokenSource = new CancellationTokenSource();
        var updater = KeepUpdatingProgressReportAsync(
            renamer.ProgressOverview,
            cancellationTokenSource.Token)
            .ConfigureAwait(false);
        foreach (var file in allFiles)
        {
            renamer.Transform(file);
        }

        cancellationTokenSource.Cancel();

        Invoke(() => renameButton.Enabled = true);

        await updater;
    }

    private async Task KeepUpdatingProgressReportAsync(
        MassOperationProgressOverview progressOverview,
        CancellationToken cancellationToken)
    {
        while (true)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Invoke(() => UpdateProgress(progressOverview));
                return;
            }

            Invoke(() => UpdateProgress(progressOverview));
            await Task.Delay(40, cancellationToken);
        }
    }

    private void UpdateProgress(MassOperationProgressOverview progressOverview)
    {
        progressBar.Maximum = progressOverview.ExpectedTotal;
        progressBar.Value = progressOverview.Total;

        updatedCountLabel.Text = progressOverview.Succeeded.ToString();
        skippedCountLabel.Text = progressOverview.Skipped.ToString();
        totalCountLabel.Text = $"{progressOverview.Total} / {progressOverview.ExpectedTotal}";
    }

    private void browseDirectoryButton_Click(object sender, EventArgs e)
    {
        var dialog = new CommonOpenFileDialog
        {
            CookieIdentifier = _browseDialogCookieIdentifier,
            IsFolderPicker = true,
        };

        var dialogResult = dialog.ShowDialog();
        if (dialogResult is CommonFileDialogResult.Ok)
        {
            beatmapsDirectoryText.Text = dialog.FileName;
        }
    }
}
