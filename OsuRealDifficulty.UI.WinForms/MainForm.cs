using OsuParsers.Database.Objects;
using OsuRealDifficulty.Mania;
using OsuRealDifficulty.UI.WinForms.Controls;
using OsuRealDifficulty.UI.WinForms.Core;
using OsuRealDifficulty.UI.WinForms.Utilities;
using Serilog;
using Serilog.Events;

namespace OsuRealDifficulty.UI.WinForms;

public partial class MainForm : Form
{
    private readonly CancellationTokenFactory _difficultyCalculationCancellationTokenFactory
        = new();

    private readonly BeatmapFilter _beatmapFilter = new();

    private DbBeatmapSet? _selectedBeatmapSet;
    private DbBeatmap? _selectedBeatmap;

    private volatile Task? _backgroundBeatmapCalculationTask = null;

    public MainForm()
    {
        InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        bool handled = HandleKeyDownShortcut(keyData);
        if (handled)
        {
            Log.Information(
                "Handled shortcut {Shortcut}",
                keyData);
            return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    private bool HandleKeyDownShortcut(Keys pressedKeys)
    {
        switch (pressedKeys)
        {
            // focus on text filter
            case Keys.Control | Keys.F:
                searchTextBox.Focus();
                return true;

            // show logs
            case Keys.Control | Keys.L:
                return true;

            // show settings
            case Keys.Control | Keys.S:
            case Keys.Control | Keys.O:
                ShowSettings();
                return true;

            // clear filters
            case Keys.Control | Keys.Alt | Keys.R:
            case Keys.Control | Keys.Alt | Keys.C:
                return true;

            // filter by keys
            case Keys.Control | Keys.K:
                keyCountFilterCheckBox.Checked = true;
                keyCountFilterTextBox.Focus();
                return true;

            // refresh all beatmaps
            case Keys.Control | Keys.Shift | Keys.R:
            {
                var reloadResult = MessageBox.Show(
                    "you pressed CTRL + SHIFT + R; do you want to reload the entire beatmap database?",
                    "reload database",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (reloadResult is DialogResult.Yes)
                {
                    ReloadMaps();
                }
                return true;
            }

            // TODO more shortcuts
        }

        return false;
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
            AppStateManager.Instance.LoadDbBeatmapSetDatabase();
            GC.Collect();
            var database = AppState.Instance.ManiaBeatmapSetDatabase!;
            beatmapSetListView.SetBeatmapSets(database.BeatmapSets);
            var end = DateTime.Now;
            var duration = end - start;
            Log.Information(
                "Loaded the entire database with {ManiaBeatmapSets} mania beatmap sets over {Time}ms",
                database.BeatmapSetCount,
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

    private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        // Convenience shortcuts:
        switch (e.KeyCode)
        {
            case Keys.Down:
                beatmapSetListView.Focus();
                break;
        }
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
        var previouslySelectedSet = GetSelectedBeatmapSet();

        var start = DateTime.Now;
        beatmapSetListView.Filter((item) => _beatmapFilter.Passes(item.BeatmapSet));
        var end = DateTime.Now;
        var filterTime = end - start;
        Log.Debug(
            "Filtered through {BeatmapSetCount} beatmap sets over {Time}ms",
            beatmapSetListView.BeatmapSetCount,
            filterTime.TotalMilliseconds);

        if (previouslySelectedSet is not null)
        {
            if (_beatmapFilter.Passes(previouslySelectedSet))
            {
                start = DateTime.Now;

                // Rediscover the set in the list to select it again
                beatmapSetListView.SelectBeatmapSet(previouslySelectedSet);

                end = DateTime.Now;
                filterTime = end - start;
                Log.Debug(
                    "Rediscovered selected beatmap set {BeatmapSetTitle} over {Time}ms",
                    previouslySelectedSet.Title,
                    filterTime.TotalMilliseconds);
            }
        }

        switch (beatmapSetListView.Items.Count)
        {
            case 1:
                beatmapSetListView.SelectIndex(0);
                break;

            case 0:
                difficultyListView.ClearBeatmaps();
                break;

            default:
                if (beatmapSetListView.SelectedIndices.Count is 0)
                {
                    difficultyListView.ClearBeatmaps();
                }
                break;
        }

        beatmapSetListView.EnsureFirstSelectedVisible();

        RunSelectedBeatmapSetFilter();
    }

    private void beatmapSetListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        var set = GetSelectedBeatmapSet();

        // nothing has changed
        if (set?.SetId == _selectedBeatmapSet?.SetId)
        {
            return;
        }
        _selectedBeatmapSet = set;

        RefreshViewForCurrentSelectedBeatmap();

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

    // TODO: FIGURE HOW TO AVOID COPY-PASTE

    private async Task HandleBeatmapCalculation(DbBeatmap dbBeatmap)
    {
        try
        {
            const string initiationTemplate
                = $"Initiated beatmap analysis for {_beatmapLogInformationTemplate}";
            LogBeatmap(
                LogEventLevel.Information,
                dbBeatmap,
                initiationTemplate);

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

            var fullResult = calculationProfile.CalculateFullResult(
                driver.AnalyzedDifficulty);
            AppState.Instance.CalculationCache.SetForBeatmap(
                dbBeatmap, fullResult);

            const string analysisCompleteTemplate
                = $"Successfully completed beatmap analysis for {_beatmapLogInformationTemplate}";
            LogBeatmap(
                LogEventLevel.Information,
                dbBeatmap,
                initiationTemplate);
        }
        catch (Exception ex)
        {
            Log.Logger.Error(ex, "Beatmap calculation threw");
        }

        Invoke(ResetCalculationEnablement);
    }

    private void TryExecuteCalculationForAllBeatmaps()
    {
        if (_backgroundBeatmapCalculationTask is not null)
            return;

        _backgroundBeatmapCalculationTask = ExecuteCalculationForAllBeatmapsAsync();
    }

    private async Task ExecuteCalculationForAllBeatmapsAsync()
    {
        var songs = AppSettings.Instance.EffectiveBaseSongsDirectory;
        foreach (var dbBeatmap in AppState.Instance.BeatmapSetDatabase!.AllBeatmaps)
        {
            try
            {
                const string initiationTemplate
                    = $"Initiated beatmap analysis for {_beatmapLogInformationTemplate}";
                LogBeatmap(
                    LogEventLevel.Information,
                    dbBeatmap,
                    initiationTemplate);

                var beatmap = dbBeatmap.Read(songs);

                var driver = CompleteBeatmapAnnotationAnalysis.NewDriver(beatmap);
                driver.ExceptionAction += AnalysisExceptionHandling;
                var source = _difficultyCalculationCancellationTokenFactory
                    .CurrentSource;

                int keys = beatmap.ManiaKeyCount();
                var executionResult = await driver.Execute(source.Token);

                foreach (var diagnostic in executionResult.Diagnostics.Diagnostics)
                {
                    LogEsotericDiagnostic(diagnostic);
                }

                const string analysisCompleteTemplate
                    = $"Successfully completed beatmap analysis for {_beatmapLogInformationTemplate}";
                LogBeatmap(
                    LogEventLevel.Information,
                    dbBeatmap,
                    initiationTemplate);

                var calculationProfile = AppState.Instance.CalculationProfiles
                    .ProfileForKeys(keys);
                var fullResult = calculationProfile.CalculateFullResult(
                    driver.AnalyzedDifficulty);
                AppState.Instance.CalculationCache.SetForBeatmap(
                    dbBeatmap, fullResult);
            }
            catch (Exception ex)
            {
                const string errorTemplate
                    = $"Beatmap calculation for {_beatmapLogInformationTemplate} threw";
                LogBeatmap(
                    LogEventLevel.Error,
                    dbBeatmap,
                    errorTemplate);
                Log.Logger.Error(ex, "Beatmap calculation threw");
            }
        }

        _backgroundBeatmapCalculationTask = null;
    }

    private const string _beatmapLogInformationTemplate
        = "{Artist} - {Title} by {Mapper} [{Difficulty}]";

    private static void LogBeatmap(
        LogEventLevel level,
        DbBeatmap beatmap,
        string template)
    {
        Log.Logger.Write(
            level,
            template,
            beatmap.RomanizedOrUnicodeArtist(),
            beatmap.RomanizedOrUnicodeTitle(),
            beatmap.Creator,
            beatmap.Difficulty);
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
        ShowSettings();
    }

    private void ShowSettings()
    {
        // TODO
    }

    private void reloadBeatmapDatabaseButton_Click(object sender, EventArgs e)
    {
        ReloadMaps();

        // Do not unnecessarily run filters right after a reload
        if (_beatmapFilter.HasAnyFilter)
        {
            RunFilter();
        }
    }

    private void showLogsButton_Click(object sender, EventArgs e)
    {

    }

    private void difficultyListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        var beatmap = GetSelectedBeatmap();
        // nothing has changed
        if (beatmap?.Difficulty == _selectedBeatmap?.Difficulty)
        {
            return;
        }
        _selectedBeatmap = beatmap;

        CancelCurrentCalculation();
        RefreshViewForCurrentSelectedBeatmap();
    }

    private void RefreshViewForCurrentSelectedBeatmap()
    {
        var beatmap = GetSelectedBeatmap();
        difficultyResultDisplay.SelectedBeatmap = beatmap;
        var cachedDifficulty = AppState.Instance.CalculationCache
            .GetForBeatmap(beatmap);
        difficultyResultDisplay.AnalyzedDifficulty = cachedDifficulty?.AnalyzedDifficulty
            ?? AnalyzedDifficulty.NewPending;
        difficultyResultDisplay.RefreshDisplay();
    }
}
