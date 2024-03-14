using OsuParsers.Database.Objects;
using OsuParsers.Enums;
using OsuRealDifficulty.Mania;
using OsuRealDifficulty.UI.WinForms.Controls;
using OsuRealDifficulty.UI.WinForms.Core;
using OsuRealDifficulty.UI.WinForms.Utilities;
using Serilog;

namespace OsuRealDifficulty.UI.WinForms;

public partial class MainForm : Form
{
    private readonly CancellationTokenFactory _difficultyCalculationCancellationTokenFactory
        = new();

    private readonly BeatmapFilter _beatmapFilter = new();

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

    private void MainForm_Shown(object sender, EventArgs e)
    {
        searchTextBox.Focus();
    }

    private void ReloadMaps()
    {
        Log.Information("Requested loading the entire database");

        beatmapSetListView.Items.Clear();
        difficultyListView.Items.Clear();

        Invoke(HandleMapReloading);
    }

    private void HandleMapReloading()
    {
        try
        {
            var start = DateTime.Now;
            AppState.Instance.LoadDbBeatmapSetDatabase();
            GC.Collect();
            var database = AppState.Instance.BeatmapSetDatabase!;
            var maniaSets = database.SetsWithRuleset(Ruleset.Mania)
                .ToList();
            beatmapSetListView.SetBeatmapSets(maniaSets);
            var end = DateTime.Now;
            var duration = end - start;
            Log.Information(
                "Loaded the entire database with {ManiaBeatmapSets} mania beatmap sets over {Time}ms",
                maniaSets.Count,
                duration.TotalMilliseconds);
        }
        catch (Exception ex)
        {
            Log.Logger.Error(ex, "Beatmap reloading threw");
        }
    }

    private void resetButton_Click(object sender, EventArgs e)
    {
        searchTextBox.Text = string.Empty;
        searchTextBox.Focus();
    }

    private void titleFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _beatmapFilter.Title = titleFilterCheckBox.Checked;
        RunFilterFocusSearchBox();
    }

    private void artistFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _beatmapFilter.Artist = artistFilterCheckBox.Checked;
        RunFilterFocusSearchBox();
    }

    private void mapperFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _beatmapFilter.Mapper = mapperFilterCheckBox.Checked;
        RunFilterFocusSearchBox();
    }

    private void difficultyFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _beatmapFilter.Difficulty = difficultyFilterCheckBox.Checked;
        RunFilterFocusSearchBox();
    }

    private void sourceFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _beatmapFilter.Source = sourceFilterCheckBox.Checked;
        RunFilterFocusSearchBox();
    }

    private void tagsFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _beatmapFilter.Tags = tagsFilterCheckBox.Checked;
        RunFilterFocusSearchBox();
    }

    private void searchTextBox_TextChanged(object sender, EventArgs e)
    {
        _beatmapFilter.Lexeme = searchTextBox.Text;
        RunFilterFocusSearchBox();
    }

    private void keyCountFilterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        bool filter = keyCountFilterCheckBox.Checked;
        keyCountFilterTextBox.Enabled = filter;
        _beatmapFilter.FilterKeyCount = filter;
        if (filter)
        {
            keyCountFilterTextBox.Focus();
        }
        else
        {
            searchTextBox.Focus();
        }
        RunFilter();
    }

    private void keyCountFilterTextBox_TextChanged(object sender, EventArgs e)
    {
        _beatmapFilter.KeyCount = keyCountFilterTextBox.KeyCount;
        RunFilter();
    }

    private void RunFilterFocusSearchBox()
    {
        searchTextBox.Focus();
        RunFilter();
    }

    private void RunFilter()
    {
        var start = DateTime.Now;
        beatmapSetListView.Filter((item) => _beatmapFilter.Passes(item.BeatmapSet));
        var end = DateTime.Now;
        var filterTime = end - start;
        Log.Debug(
            "Filtered through {BeatmapSetCount} beatmap sets over {Time}ms",
            beatmapSetListView.BeatmapSetCount,
            filterTime.TotalMilliseconds);

        switch (beatmapSetListView.Items.Count)
        {
            case 1:
                beatmapSetListView.SelectIndex(0);
                break;

            case 0:
                difficultyListView.ClearBeatmaps();
                break;
        }

        RunSelectedBeatmapSetFilter();
    }

    private void beatmapSetListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        var set = GetSelectedBeatmapSet();
        if (set is null)
        {
            difficultyListView.ClearBeatmaps();
            return;
        }

        CancelCurrentCalculation();

        var maniaDifficulties = set.WithManiaRuleset();
        difficultyListView.SetBeatmaps(maniaDifficulties);
        RunSelectedBeatmapSetFilter();
    }

    private void RunSelectedBeatmapSetFilter()
    {
        difficultyListView.Filter((item) => _beatmapFilter.PassesIgnoreLexeme(item.Beatmap));
        switch (difficultyListView.Items.Count)
        {
            case 1:
                difficultyListView.SelectIndex(0);
                break;
        }
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
        return selectedItem?.Beatmap;
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
        beginCalculationButton.Enabled = false;
        cancelCalculationButton.Enabled = true;

        Invoke(async () => await HandleBeatmapCalculation(dbBeatmap));
    }

    private async Task HandleBeatmapCalculation(DbBeatmap dbBeatmap)
    {
        try
        {
            var songs = AppSettings.Instance.EffectiveBaseSongsDirectory;
            var beatmap = dbBeatmap.Read(songs);

            var driver = CompleteBeatmapAnnotationAnalysis.NewDriver(beatmap);
            driver.ExceptionAction += AnalysisExceptionHandling;
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
            var executionResult = await driver.Execute(source.Token);
            difficultyResultDisplay.RefreshDisplay();
            difficultyResultDisplay.StopListeningForRequests();

            foreach (var diagnostic in executionResult.Diagnostics.Diagnostics)
            {
                LogEsotericDiagnostic(diagnostic);
            }
        }
        catch (Exception ex)
        {
            Log.Logger.Error(ex, "Beatmap calculation threw");
        }

        Invoke(ResetCalculationEnablement);
    }

    private static void LogEsotericDiagnostic(EsotericDiagnostic diagnostic)
    {
        Log.Warning($$"""
            Esoteric diagnostic reported during analysis
            {{{nameof(diagnostic.Message)}}}
            Called by {{{nameof(diagnostic.CallerName)}}}
            Called at {{{nameof(diagnostic.CallerFile)}}} : Line {{{nameof(diagnostic.CallerLine)}}}
            """,
            diagnostic.Message,
            diagnostic.CallerName,
            diagnostic.CallerFile,
            diagnostic.CallerLine);
    }

    private void AnalysisExceptionHandling(Exception ex)
    {
        Log.Error(ex, "Exception thrown during analysis");
    }

    private void ResetCalculationEnablement()
    {
        beginCalculationButton.Enabled = true;
        cancelCalculationButton.Enabled = false;
    }

    private void cancelCalculationButton_Click(object sender, EventArgs e)
    {
        CancelCurrentCalculation();
        // We do not want to handle anything else here;
        // the cancellation should propagate into refreshing the rest of the program
    }

    private void CancelCurrentCalculation()
    {
        _difficultyCalculationCancellationTokenFactory
            .CurrentSource.Cancel();
    }

    private void settingsButton_Click(object sender, EventArgs e)
    {

    }

    private void reloadBeatmapDatabaseButton_Click(object sender, EventArgs e)
    {
        ReloadMaps();
        RunFilter();
    }

    private void showLogsButton_Click(object sender, EventArgs e)
    {

    }

    private void difficultyListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        CancelCurrentCalculation();
    }
}
