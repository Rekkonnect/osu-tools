using OsuParsers.Database.Objects;
using OsuParsers.Enums;
using OsuRealDifficulty.Mania;
using OsuRealDifficulty.UI.WinForms.Controls;
using OsuRealDifficulty.UI.WinForms.Core;

namespace OsuRealDifficulty.UI.WinForms;

public partial class MainForm : Form
{
    private CancellationTokenFactory _difficultyCalculationCancellationTokenFactory = new();

    private BeatmapFilter _beatmapFilter = new();

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
        beatmapSetListView.Items.Clear();
        difficultyListView.Items.Clear();

        Invoke(HandleMapReloading);
    }

    private void HandleMapReloading()
    {
        try
        {
            AppState.Instance.LoadDbBeatmapSetDatabase();
            GC.Collect();
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
        beatmapSetListView.Filter((item) => _beatmapFilter.Passes(item.BeatmapSet));
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
    }

    private void showLogsButton_Click(object sender, EventArgs e)
    {

    }

    private void difficultyListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        CancelCurrentCalculation();
    }
}
