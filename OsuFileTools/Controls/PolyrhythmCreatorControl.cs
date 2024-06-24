using OsuFileTools.Core;
using OsuParsers.Encoders;
using OsuTools.Common;

namespace OsuFileTools.Controls;

public partial class PolyrhythmCreatorControl : UserControl
{
    public PolyrhythmCreatorControl()
    {
        InitializeComponent();
    }

    private void loadSourceNotationButton_Click(object sender, EventArgs e)
    {
        RequestLoadingNotation();
    }

    private void RequestLoadingNotation()
    {
        var result = loadNotationDialog.ShowDialog();
        if (result is DialogResult.OK)
        {
            try
            {
                var path = loadNotationDialog.FileName;
                LoadNotation(path);
            }
            catch (Exception ex)
            {
                var errorResult = MessageBox.Show(
                    $"""
                    Failed to load the specified notation file. Try again?
                    
                    Error details: {ex.GetType().FullName}
                    {ex.Message}
                    """,
                    "Loading failed",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (errorResult is DialogResult.Yes)
                {
                    RequestLoadingNotation();
                }
            }
        }
    }

    private void LoadNotation(string path)
    {
        var notation = File.ReadAllText(path);
        sourceNotationText.Text = notation;
    }

    private void createTimingPointsButton_Click(object sender, EventArgs e)
    {
        try
        {
            CreateTimingPoints();
        }
        catch (Exception ex)
        {
            var errorResult = MessageBox.Show(
                $"""
                    Failed to create the timing points.
                    
                    Error details: {ex.GetType().FullName}
                    {ex.Message}
                    """,
                "Generation failed",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (errorResult is DialogResult.Yes)
            {
                RequestLoadingNotation();
            }
        }
    }

    private void CreateTimingPoints()
    {
        var text = sourceNotationText.Text;
        var section = PolyrhythmSectionParser.Parse(text);
        var options = new PolyrhythmTimingPointCreationOptions
        {
            NormalizedBeatLength = BeatLength.FromBpm((double)normalizedBpmNumeric.Value),
            NoteBeatDivisor = (int)normalBeatDivisorNumeric.Value,
        };
        var creator = new PolyrhythmTimingPointCreator();
        var points = creator.CreateTimingPoints(section, options);

        var encodedTimingPoints = BeatmapEncoder.TimingPoints(points.TimingPoints);
        outputTimingPointsText.Text = string.Join(
            Environment.NewLine,
            encodedTimingPoints);
    }
}
