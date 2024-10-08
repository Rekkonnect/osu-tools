﻿using OsuFileTools.Core;
using OsuParsers.Beatmaps;
using OsuParsers.Decoders;
using OsuParsers.Encoders;
using OsuTools.Common;

namespace OsuFileTools.Controls;

public partial class BeatmapTransformerControl : UserControl
{
    private static readonly Guid _fileDialogGuid = new("9787CB0F-FA2F-4699-B03B-849043754355");

    private Beatmap _sourceBeatmap;
    private Beatmap _transformedBeatmap;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public BeatmapTransformerControl()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        InitializeComponent();

        loadBeatmapDialog.ClientGuid = _fileDialogGuid;
        saveDialogBeatmap.ClientGuid = _fileDialogGuid;
    }

    private void applyTimingPointResnapButton_Click(object sender, EventArgs e)
    {
        var options = new TimingPointResnapper.Options();
        var previousBpm = (double)timingPointResnapperPreviousBpm.Value;
        if (previousBpm > 0)
        {
            options.PreviousBeatLength = BeatLength.FromBpm(previousBpm);
        }

        options.TimingSignatureDivisor = (int)timingPointResnapperDivisor.Value;

        var resnapper = new TimingPointResnapper(options);
        ApplyTransformation(resnapper);
    }

    private void applyInheritedTimingPointButton_Click(object sender, EventArgs e)
    {
        var options = new InheritedTimingPointCreator.Options();
        var baselineBpm = (double)inheritedTimingPointCreatorBaselineBpmNumeric.Value;
        options.BaselineBpm = baselineBpm;

        var creator = new InheritedTimingPointCreator(options);
        ApplyTransformation(creator);
    }

    private void applyGlobalOffsetMoveButton_Click(object sender, EventArgs e)
    {
        var options = new GlobalOffsetMover.Options
        {
            OffsetStart = (double)globalOffsetMoverOffsetStartNumeric.Value,
            OffsetEnd = (double)globalOffsetMoverOffsetEndNumeric.Value,
            MoveBy = (double)globalOffsetMoverMoveOffsetsByNumeric.Value,
        };

        var mover = new GlobalOffsetMover(options);
        ApplyTransformation(mover);
    }

    private void ApplyTransformation(ITransformer transformer)
    {
        bool loaded = EvaluateBeatmapLoadStatus();
        if (!loaded)
            return;

        var beatmap = _transformedBeatmap;
        var newBeatmap = transformer.Transform(beatmap);
        _transformedBeatmap = newBeatmap;
        transformedBeatmapText.Lines = BeatmapEncoder.Encode(newBeatmap).ToArray();
    }

    private bool EvaluateBeatmapLoadStatus()
    {
        if (_transformedBeatmap is null)
        {
            MessageBox.Show(
                $"""
                Please load a beatmap from the source beatmap panel.
                """,
                "No beatmap loaded",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }

        return true;
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
        bool loaded = EvaluateBeatmapLoadStatus();
        if (!loaded)
            return;

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
