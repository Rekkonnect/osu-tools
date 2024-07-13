using OsuFileTools.Core;
using OsuParsers.Decoders;

namespace OsuFileTools.Controls;

public partial class HitsoundExtractorControl : UserControl
{
    private static readonly Guid _fileDialogGuid = new("DBAC8CE1-B73A-4F08-ACAE-B748927CBFD0");

    public HitsoundExtractorControl()
    {
        InitializeComponent();

        openFileDialog.ClientGuid = _fileDialogGuid;
        openFileDialog.InitialDirectory = "%localappdata%/osu!/Songs/";
    }

    private void sourceBrowseButton_Click(object sender, EventArgs e)
    {
        RequestFilePath(sourcePathText);
    }

    private void targetBrowseButton_Click(object sender, EventArgs e)
    {
        RequestFilePath(targetPathText);
    }

    private void performOperationButton_Click(object sender, EventArgs e)
    {
        PerformOperation();
    }

    private void RequestFilePath(TextBox pathText)
    {
        var dialogResult = openFileDialog.ShowDialog();
        if (dialogResult is not DialogResult.OK)
            return;

        var path = openFileDialog.FileName;
        pathText.Text = path;
    }

    private void PerformOperation()
    {
        try
        {
            var sourcePath = sourcePathText.Text;
            var sourceFile = new FileInfo(sourcePath);
            var sourceBeatmap = BeatmapDecoder.Decode(sourceFile);
            var options = new HitsoundExtractor.Options
            {
                IncludeStoryboardSounds = includeStoryboardSoundsCheck.Checked,
                KeyCount = (int)keyCountNumeric.Value,
                HitsoundDifficultyName = hitsoundDifficultyText.Text,
                ConvertLongNotesToRice = convertLongNotesToRiceCheck.Checked,
            };
            var extractor = new HitsoundExtractor(options);
            var targetBeatmap = extractor.Transform(sourceBeatmap);
            var targetFile = new FileInfo(targetPathText.Text);
            targetBeatmap.Save(targetFile);

            MessageBox.Show(
                $"""
                Successfully extracted the hit sounds
                """,
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            var errorResult = MessageBox.Show(
                $"""
                An error occurred while trying to extract the beatmap's hitsounds. Try again?
                    
                Error details: {ex.GetType().FullName}
                {ex.Message}
                """,
                "Error",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (errorResult is DialogResult.Yes)
            {
                PerformOperation();
            }
        }
    }
}
