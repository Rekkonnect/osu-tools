using OsuRealDifficulty.UI.WinForms.Core;
using System.Diagnostics;

namespace OsuRealDifficulty.UI.WinForms;

public partial class SettingsForm : ThemeFontForm
{
    // disabled because the BindTo extensions are not properly implemented
    private static readonly bool _enableBindings = false;

    public SettingsForm()
    {
        InitializeComponent();

        if (_enableBindings)
        {
            BindControls();
        }

        ReadDisplaySettings();
    }

    private void BindControls()
    {
        analyzeSingleBeatmapOnSelectionCheckBox.BindTo(
            () => AppSettings.Instance.AnalyzeOnSelection);

        analyzeBeatmapSetOnSelection.BindTo(
            () => AppSettings.Instance.AnalyzeSetOnSelection);

        invalidateCachedCalculationsOnRefreshCheckBox.BindTo(
            () => AppSettings.Instance.InvalidateAllCachedCalculationsOnRefresh);

        analyzeAllBeatmapsOnStartupCheckBox.BindTo(
            () => AppSettings.Instance.AnalyzeAllOnStartup);

        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.BindTo(
            () => AppSettings.Instance.AnalyzeAllOnDatabaseRefresh);

        baseOsuDirectoryTextBox.BindTo(
            () => AppSettings.Instance.BaseOsuDataDirectoryString);

        beatmapDirectoryTextBox.BindTo(
            () => AppSettings.Instance.BaseBeatmapsDirectoryString);
    }

    private void ReadDisplaySettings()
    {
        analyzeSingleBeatmapOnSelectionCheckBox.Checked
            = AppSettings.Instance.AnalyzeOnSelection;

        analyzeBeatmapSetOnSelection.Checked
            = AppSettings.Instance.AnalyzeSetOnSelection;

        invalidateCachedCalculationsOnRefreshCheckBox.Checked
            = AppSettings.Instance.InvalidateAllCachedCalculationsOnRefresh;

        analyzeAllBeatmapsOnStartupCheckBox.Checked
            = AppSettings.Instance.AnalyzeAllOnStartup;

        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.Checked
            = AppSettings.Instance.AnalyzeAllOnDatabaseRefresh;

        baseOsuDirectoryTextBox.Text
            = AppSettings.Instance.BaseOsuDataDirectoryString;

        beatmapDirectoryTextBox.Text
            = AppSettings.Instance.BaseBeatmapsDirectoryString;
    }

    private void analyzeSingleBeatmapOnSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.Instance.AnalyzeOnSelection =
            analyzeSingleBeatmapOnSelectionCheckBox.Checked;
    }

    private void analyzeBeatmapSetOnSelection_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.Instance.AnalyzeSetOnSelection =
            analyzeBeatmapSetOnSelection.Checked;
    }

    private void invalidateCachedCalculationsOnRefreshCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.Instance.InvalidateAllCachedCalculationsOnRefresh =
            invalidateCachedCalculationsOnRefreshCheckBox.Checked;
    }

    private void analyzeAllBeatmapsOnStartupCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.Instance.AnalyzeAllOnStartup =
            analyzeAllBeatmapsOnStartupCheckBox.Checked;
    }

    private void analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.Instance.AnalyzeAllOnDatabaseRefresh =
            analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.Checked;
    }

    private void baseOsuDirectoryTextBox_TextChanged(object sender, EventArgs e)
    {
        AppSettings.Instance.BaseOsuDataDirectoryString =
            baseOsuDirectoryTextBox.Text;
    }

    private void beatmapDirectoryTextBox_TextChanged(object sender, EventArgs e)
    {
        AppSettings.Instance.BaseBeatmapsDirectoryString =
            beatmapDirectoryTextBox.Text;
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        AppSettingsManager.Instance.Save(AppSettings.Instance);
    }

    private void resetButton_Click(object sender, EventArgs e)
    {
        AppSettingsManager.Instance.OverwriteSettingsInstance();
        ReadDisplaySettings();
    }

    private void openSettingsFileButton_Click(object sender, EventArgs e)
    {
        var path = AppSettingsManager.Instance.FilePath;
        Process.Start("notepad.exe", path.FullName);
    }
}
