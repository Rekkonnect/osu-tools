using OsuParsers.Database.Objects;
using OsuParsers.Enums;
using OsuRealDifficulty.Mania;
using OsuRealDifficulty.UI.WinForms.Controls;
using OsuRealDifficulty.UI.WinForms.Core;
using System.Configuration;
using System.Reflection;

namespace OsuRealDifficulty.UI.WinForms;

public partial class MainForm : Form
{
    private CancellationTokenFactory _difficultyCalculationCancellationTokenFactory = new();

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Text = ApplicationMetadata.FullTitle;

        var fontFamily = ThemeFonts.Instance.MainFontFamily;
        this.RecursivelyReplaceFontFamilyWithMain(fontFamily);

        ReloadMaps();
    }

    private void ReloadMaps()
    {
        beatmapGroupBox.Enabled = false;

        Invoke(HandleMapReloading);
    }

    private void HandleMapReloading()
    {
        try
        {
            beatmapSetListView.Items.Clear();
            difficultyListView.Items.Clear();

            AppState.Instance.LoadDbBeatmapSetDatabase();
            var database = AppState.Instance.BeatmapSetDatabase!;
            var maniaSets = database.SetsWithRuleset(Ruleset.Mania);
            beatmapSetListView.SetBeatmapSets(maniaSets);
        }
        catch (Exception ex)
        {
            // Log it somewhere
        }
        finally
        {

        }

        beatmapGroupBox.Enabled = true;
    }

    private void resetButton_Click(object sender, EventArgs e)
    {
        searchTextBox.Text = string.Empty;
    }

    private void titleFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void artistFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void mapperFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void difficultyFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void keyCountFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        keyCountFilterCheckBox.Enabled = keyCountFilterCheckBox.Checked;
    }

    private void searchTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void beatmapSetListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        var set = GetSelectedBeatmapSet();
        if (set is null)
            return;

        var maniaDifficulties = set.WithManiaRuleset();
        difficultyListView.SetBeatmaps(maniaDifficulties);
    }

    private DbBeatmapSet? GetSelectedBeatmapSet()
    {
        var selectedItems = beatmapSetListView.SelectedItems;
        if (selectedItems.Count is not 1)
            return null;

        var selectedItem = selectedItems[0] as BeatmapSetListViewItem;
        return selectedItem?.BeatmapSet;
    }

    private DbBeatmap? GetSelectedBeatmap()
    {
        var selectedItems = difficultyListView.SelectedItems;
        if (selectedItems.Count is not 1)
            return null;

        var selectedItem = selectedItems[0] as BeatmapListViewItem;
        return selectedItem!.Beatmap;
    }

    private void beginCalculationButton_Click(object sender, EventArgs e)
    {
        var beatmap = GetSelectedBeatmap();
        if (beatmap is null)
        {
            MessageBox.Show(
                "please select a beatmap from the bottom list view",
                "no beatmap selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        CalculateBeatmapDifficulty(beatmap);
    }

    private void CalculateBeatmapDifficulty(DbBeatmap dbBeatmap)
    {
        beatmapGroupBox.Enabled = false;
        beginCalculationButton.Enabled = false;
        cancelCalculationButton.Enabled = true;

        Task.Run(() => HandleBeatmapCalculation(dbBeatmap));
    }

    private async Task HandleBeatmapCalculation(DbBeatmap dbBeatmap)
    {
        try
        {
            var songs = AppSettings.Instance.EffectiveBaseSongsDirectory;
            var beatmap = dbBeatmap.Read(songs);

            var driver = CompleteBeatmapAnnotationAnalysis.NewDriver(beatmap);
            var source = _difficultyCalculationCancellationTokenFactory
                .CurrentSource;

            int keys = beatmap.ManiaKeyCount();
            var calculationProfile = AppState.Instance.CalculationProfiles
                .ProfileForKeys(keys);
            difficultyResultDisplay.CalculationProfile = calculationProfile;
            difficultyResultDisplay.AnalyzedDifficulty = driver.AnalyzedDifficulty;
            difficultyResultDisplay.BeginListeningForRequests(
                driver.AnalyzerExecutionRequestChannel,
                source);
            await driver.Execute(source.Token);
            difficultyResultDisplay.RefreshDisplay();
            difficultyResultDisplay.StopListeningForRequests();
        }
        catch (Exception ex)
        {
            // Log it somewhere
        }
        finally
        {

        }

        Invoke(ResetCalculationEnablement);
    }

    private void ResetCalculationEnablement()
    {
        beatmapGroupBox.Enabled = true;
        beginCalculationButton.Enabled = true;
        cancelCalculationButton.Enabled = false;
    }

    private void cancelCalculationButton_Click(object sender, EventArgs e)
    {
        _difficultyCalculationCancellationTokenFactory
            .CurrentSource.Cancel();
        // We do not want to handle anything else here;
        // the cancellation should propagate into refreshing the rest of the program
    }

    private void settingsButton_Click(object sender, EventArgs e)
    {

    }

    private void reloadBeatmapDatabaseButton_Click(object sender, EventArgs e)
    {
        ReloadMaps();
    }

    private void showLogsButton_Click(object sender, EventArgs e)
    {

    }
}

public sealed class CancellationTokenFactory
{
    private CancellationTokenSource? _currentSource;

    public CancellationTokenSource CurrentSource
    {
        get
        {
            if (_currentSource is null)
            {
                return CreateSource();
            }

            if (_currentSource.IsCancellationRequested)
            {
                return CreateSource();
            }

            return _currentSource;
        }
    }

    public CancellationToken CurrentToken => CurrentSource.Token;

    public CancellationTokenSource CreateSource()
    {
        _currentSource = new CancellationTokenSource();
        return _currentSource;
    }
}
