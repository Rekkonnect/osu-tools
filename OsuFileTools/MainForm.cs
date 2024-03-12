using OsuParsers.Beatmaps;
using OsuParsers.Decoders;
using OsuParsers.Encoders;

namespace OsuFileTools;

public partial class MainForm : Form
{
    private Beatmap _sourceBeatmap;
    private Beatmap _transformedBeatmap;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public MainForm()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        InitializeComponent();
    }

    private void applyTimingPointResnapButton_Click(object sender, EventArgs e)
    {
        var options = new TimingPointResnappingOptions();
        var previousBeatLength = (double)timingPointResnapperPreviousBeatLength.Value;
        if (previousBeatLength > 0)
        {
            options.PreviousBeatLength = new(previousBeatLength);
        }

        options.TimingSignatureDivisor = (int)timingPointResnapperDivisor.Value;

        var resnapper = new TimingPointResnapper { Options = options };
        ApplyTransformation(resnapper);
    }

    private void ApplyTransformation(ITransformer transformer)
    {
        var beatmap = _transformedBeatmap;
        var newBeatmap = transformer.Transform(beatmap);
        _transformedBeatmap = newBeatmap;
        transformedBeatmapText.Lines = BeatmapEncoder.Encode(newBeatmap).ToArray();
    }

    private void LoadBeatmap(string path)
    {
        var lines = File.ReadAllLines(path);
        var beatmap = BeatmapDecoder.Decode(lines);
        _sourceBeatmap = beatmap;
        _transformedBeatmap = beatmap;
        sourceBeatmapText.Lines = lines;
        transformedBeatmapText.Lines = lines;
    }

    private void SaveBeatmap(string path)
    {
        _transformedBeatmap.Save(path);
    }

    private void RequestLoadingBeatmap()
    {
        var result = loadBeatmapDialog.ShowDialog();
        if (result is DialogResult.OK)
        {
            try
            {
                var path = loadBeatmapDialog.FileName;
                LoadBeatmap(path);
                // Also store the expected path
                saveDialogBeatmap.InitialDirectory = loadBeatmapDialog.InitialDirectory;
            }
            catch (Exception ex)
            {
                var errorResult = MessageBox.Show(
                    $"""
                    The beatmap you chose to load is invalid. Try again?
                    
                    Error details: {ex.GetType().FullName}
                    {ex.Message}
                    """,
                    "Invalid beatmap",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (errorResult is DialogResult.Yes)
                {
                    RequestLoadingBeatmap();
                }
            }
        }
    }

    private void RevertTransformedBeatmap()
    {
        _transformedBeatmap = _sourceBeatmap;
        transformedBeatmapText.Text = sourceBeatmapText.Text;
    }

    private void RequestSavingBeatmap()
    {
        var result = saveDialogBeatmap.ShowDialog();
        if (result is DialogResult.OK)
        {
            try
            {
                var path = saveDialogBeatmap.FileName;
                SaveBeatmap(path);
            }
            catch (Exception ex)
            {
                var errorResult = MessageBox.Show(
                    $"""
                    An error occurred while trying to save the beatmap. Try again?
                    
                    Error details: {ex.GetType().FullName}
                    {ex.Message}
                    """,
                    "Error saving beatmap",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (errorResult is DialogResult.Yes)
                {
                    RequestSavingBeatmap();
                }
            }
        }
    }

    private void loadSourceBeatmapButton_Click(object sender, EventArgs e)
    {
        RequestLoadingBeatmap();
    }

    private void revertTransformedBeatmapButton_Click(object sender, EventArgs e)
    {
        RevertTransformedBeatmap();
    }

    private void saveTransformedBeatmapButton_Click(object sender, EventArgs e)
    {
        RequestSavingBeatmap();
    }
}
