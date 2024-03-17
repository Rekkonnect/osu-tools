using OsuParsers.Database.Objects;
using OsuRealDifficulty.Mania;
using OsuRealDifficulty.UI.WinForms.Controls;
using OsuRealDifficulty.UI.WinForms.Core;
using OsuRealDifficulty.UI.WinForms.Utilities;
using Serilog;
using Serilog.Events;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory;

namespace OsuRealDifficulty.UI.WinForms;

public partial class MainForm : Form
{
    private readonly CancellationTokenFactory _difficultyCalculationCancellationTokenFactory
        = new();

    private readonly BeatmapFilter _beatmapFilter = new();
    private readonly CurrentBeatmapSelection _beatmapSelection = new();
    private readonly BackgroundCalculationInformation _backgroundCalculationInformation
        = new();

    private PopupBoxManager _popupBoxManager;
    private bool _hasRunAllBeatmaps = false;
    private volatile Task? _backgroundBeatmapCalculationTask = null;

    public MainForm()
    {
        InitializeComponent();
        SetupEvents();
    }

    [MemberNotNull(nameof(_popupBoxManager))]
    private void SetupEvents()
    {
        _beatmapSelection.BeatmapSetChanged += SelectedBeatmapSetChanged;
        _beatmapSelection.BeatmapChanged += SelectedBeatmapChanged;

        backgroundCalculationReporter.BindToBackgroundCalculationInformation(
            _backgroundCalculationInformation);

        _popupBoxManager = new(this);
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
                searchTextBox.SelectAll();
                return true;

            // show logs
            case Keys.Control | Keys.L:
                ShowLogs();
                return true;

            // show settings
            case Keys.Control | Keys.S:
            case Keys.Control | Keys.O:
                ShowSettings();
                return true;

            // clear filters
            case Keys.Control | Keys.Alt | Keys.R:
            case Keys.Control | Keys.Alt | Keys.C:
                ClearFilter();
                return true;

            // filter by keys
            case Keys.Control | Keys.K:
                keyCountFilterCheckBox.Checked = true;
                keyCountFilterTextBox.Focus();
                return true;

            // refresh all beatmaps
            case Keys.Control | Keys.Shift | Keys.R:
            {
                var popup = new PopupBox
                {
                    Title =
                        "reload database",
                    Message = """
                        you pressed CTRL + SHIFT + R
                        do you want to reload the entire beatmap database?
                        """,
                    MessageIcon = MessageBoxIcon.Question,
                };
                popup.AddButton(DialogResult.Yes, "yes");
                popup.AddButton(DialogResult.No, "no");
                popup.YesSelected += ReloadMaps;
                _popupBoxManager.Show(popup);

                return true;
            }

            // calculate selected beatmap
            case Keys.Control | Keys.M:
            {
                CalculateSelectedBeatmap();
                return true;
            }

            // calculate all beatmaps
            case Keys.Control | Keys.Shift | Keys.M:
            {
                TryExecuteCalculationForAllBeatmaps();
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

        if (AppSettings.Instance.AnalyzeAllOnStartup)
        {
            TryExecuteCalculationForAllBeatmaps();
        }
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
        ClearFilter();
    }

    private void ClearFilter()
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
        // convenience shortcuts
        switch (e.KeyCode)
        {
            case Keys.Down:
                FocusBeatmapSetListViewSelectFirstIfNone();
                break;

            case Keys.Escape:
                searchTextBox.Text = string.Empty;
                break;
        }
    }

    private void FocusBeatmapSetListViewSelectFirstIfNone()
    {
        beatmapSetListView.Focus();
        int selectedCount = beatmapSetListView.SelectedItems.Count;
        if (selectedCount is 0 && beatmapSetListView.Items.Count > 0)
        {
            beatmapSetListView.SelectedIndices.Add(0);
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

    private void beatmapSetListView_ItemSelectionChanged(
        object sender, ListViewItemSelectionChangedEventArgs e)
    {
        var set = GetSelectedBeatmapSet();
        _beatmapSelection.BeatmapSet = set;
    }

    private void RunSelectedBeatmapSetFilter()
    {
        difficultyListView.Filter((item) => _beatmapFilter.PassesIgnoreLexeme(item.Beatmap));
        switch (difficultyListView.Items.Count)
        {
            case 1:
                difficultyListView.SelectIndex(0);
                break;
            default:
                difficultyListView.SelectedIndices.Clear();
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
        CalculateSelectedBeatmap();
    }

    private void CalculateSelectedBeatmap()
    {
        var beatmap = _beatmapSelection.Beatmap;
        if (beatmap is null)
        {
            var popup = new PopupBox
            {
                Title =
                    "no beatmap selected",
                Message = """
                    please select a beatmap from the bottom list view
                    """,
                MessageIcon = MessageBoxIcon.Error,
            };
            popup.AddButton(DialogResult.OK, "ok");
            _popupBoxManager.Show(popup);
            return;
        }

        CalculateBeatmapDifficulty(beatmap);
    }

    private void CalculateBeatmapDifficulty(DbBeatmap dbBeatmap)
    {
        beginCalculationButton.Enabled = false;
        cancelCalculationButton.Enabled = true;

        Invoke(async () => await HandleBeatmapCalculation(dbBeatmap, true));
    }

    private async Task HandleBeatmapCalculation(DbBeatmap dbBeatmap, bool listenToAnalysis)
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
            int keys = beatmap.ManiaKeyCount();
            var calculationProfile = AppState.Instance.CalculationProfiles
                .ProfileForKeys(keys);
            driver.DifficultyCalculationProfile = calculationProfile;
            driver.ExceptionAction += AnalysisExceptionHandling;
            var source = _difficultyCalculationCancellationTokenFactory
                .CurrentSource;

            if (listenToAnalysis)
            {
                difficultyResultDisplay.DifficultyCalculationResult
                    = driver.FullDifficultyCalculationResult;
                difficultyResultDisplay.BeginListeningForRequests(
                    driver.AnalyzerExecutionRequestChannel,
                    source);
            }

            var executionResult = await driver.Execute(source.Token);
            var finalResult = driver.FullDifficultyCalculationResult;

            if (listenToAnalysis)
            {
                difficultyResultDisplay.DifficultyCalculationResult = finalResult;
                difficultyResultDisplay.RefreshDisplay();
                difficultyResultDisplay.StopListeningForRequests();
            }

            foreach (var diagnostic in executionResult.Diagnostics.Diagnostics)
            {
                LogEsotericDiagnostic(diagnostic);
            }

            AppState.Instance.CalculationCache.SetForBeatmap(
                dbBeatmap, finalResult);

            const string analysisCompleteTemplate
                = $"Successfully completed beatmap analysis for {_beatmapLogInformationTemplate}";
            LogBeatmap(
                LogEventLevel.Information,
                dbBeatmap,
                analysisCompleteTemplate);
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

        RequestExecuteCalculationForAllBeatmaps();
    }

    private void HandleConfirmedBackgroundCalculation(DialogResult result)
    {
        if (result is not DialogResult.Yes)
            return;

        beginCalculateAllBeatmapsButton.Enabled = false;
        _backgroundBeatmapCalculationTask = ExecuteCalculationForAllBeatmapsAsync();
    }

    private void RequestExecuteCalculationForAllBeatmaps()
    {
        string coldFirstRunNote = string.Empty;
        if (!_hasRunAllBeatmaps)
        {
            coldFirstRunNote = "note: the first run of all beatmaps may be vastly slower";
        }
        var popup = new PopupBox
        {
            Title =
                "background calculation of all beatmaps",
            Message = $"""
                calculating all beatmaps in the background will severely
                degrade performance of the application until it's done
                continue?

                {coldFirstRunNote}
                """,
            MessageIcon = MessageBoxIcon.Warning,
        };
        popup.AddButton(DialogResult.Yes, "yes");
        popup.AddButton(DialogResult.No, "no");

        popup.ResultSelected += HandleConfirmedBackgroundCalculation;
        _popupBoxManager.Show(popup);
    }

    private async Task ExecuteCalculationForAllBeatmapsAsync()
    {
        // PROBLEM: this causes tons of GC collections, effectively
        // killing the performance of the application, and vastly
        // underutilizing the CPU
        // this happens because parsing the beatmaps themselves
        // allocates tons of objects, both from the parsing library
        // and the annotation analysis
        // the only solution to this problem is to run a separate
        // process to perform the calculation, in order to outsource
        // the GC overhead, and communicate the results in real-time
        // via some clever inter-process mechanism
        // this is not a massive concern for now, as long as the
        // application doesn't completely freeze and doesn't hog
        // tons of resources

        var songs = AppSettings.Instance.EffectiveBaseSongsDirectory;
        var allBeatmaps = AppState.Instance
            .ManiaBeatmapSetDatabase!.AllBeatmaps.ToArray();
        _backgroundCalculationInformation.Initiate(allBeatmaps.Length);
        foreach (var dbBeatmap in allBeatmaps)
        {
            try
            {
                await HandleBeatmapCalculation(dbBeatmap, false);
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

            _backgroundCalculationInformation.RegisterCalculationComplete();
        }

        _backgroundCalculationInformation.FinishCalculation();
        _backgroundBeatmapCalculationTask = null;
        _hasRunAllBeatmaps = true;
        Invoke(() => beginCalculateAllBeatmapsButton.Enabled = true);
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
        ShowLogs();
    }

    private void ShowLogs()
    {
        LogViewForm.Open();
    }

    private void difficultyListView_ItemSelectionChanged(
        object sender, ListViewItemSelectionChangedEventArgs e)
    {
        // ISSUE: this triggers twice per selection,
        // once for the deselection of the previous item
        // and another one time for the selection of the current item
        // this does not matter much since we don't perform any intensive
        // operations other than retrieving the cache for a null beatmap

        var beatmap = GetSelectedBeatmap();
        _beatmapSelection.Beatmap = beatmap;
    }

    private void SelectedBeatmapSetChanged(DbBeatmapSet? set)
    {
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

    private void SelectedBeatmapChanged(DbBeatmap? beatmap)
    {
        CancelCurrentCalculation();
        RefreshViewForCurrentSelectedBeatmap();
    }

    private void RefreshViewForCurrentSelectedBeatmap()
    {
        var beatmap = _beatmapSelection.Beatmap;
        difficultyResultDisplay.SelectedBeatmap = beatmap;
        var cachedDifficulty = AppState.Instance.CalculationCache
            .GetForBeatmap(beatmap);
        difficultyResultDisplay.RefreshDisplay(
            cachedDifficulty);
    }

    private void beginCalculateAllBeatmapsButton_Click(object sender, EventArgs e)
    {
        TryExecuteCalculationForAllBeatmaps();
    }

    private class CurrentBeatmapSelection
    {
        private DbBeatmapSet? _beatmapSet;
        private DbBeatmap? _beatmap;

        public DbBeatmapSet? BeatmapSet
        {
            get
            {
                return _beatmapSet;
            }
            set
            {
                if (AreBeatmapSetsEqual(_beatmapSet, value))
                    return;

                _beatmapSet = value;
                BeatmapSetChanged?.Invoke(value);
            }
        }

        public DbBeatmap? Beatmap
        {
            get
            {
                return _beatmap;
            }
            set
            {
                if (AreBeatmapsEqual(_beatmap, value))
                    return;

                _beatmap = value;
                BeatmapChanged?.Invoke(value);
            }
        }

        public event Action<DbBeatmapSet?>? BeatmapSetChanged;
        public event Action<DbBeatmap?>? BeatmapChanged;

        private static bool AreBeatmapSetsEqual(DbBeatmapSet? x, DbBeatmapSet? y)
        {
            return x?.SetId == y?.SetId;
        }
        private static bool AreBeatmapsEqual(DbBeatmap? x, DbBeatmap? y)
        {
            var definitelyEqual = AreDefinitelyEqual(x, y);
            if (definitelyEqual is not null)
            {
                return definitelyEqual.Value;
            }

            // enough checks -- we don't have to overdo it
            return x!.BeatmapId == y!.BeatmapId
                && x.Difficulty == y.Difficulty
                && x.BeatmapSetId == y.BeatmapSetId;
        }

        private static bool? AreDefinitelyEqual(object? x, object? y)
        {
            bool xn = x is null;
            bool yn = y is null;

            if (xn && yn)
                return true;

            if (xn ^ yn)
                return false;

            return null;
        }
    }
}
