﻿using OsuParsers.Encoders;

namespace OsuFileTools;

public partial class SimpleGeneratorsControl : UserControl
{
    public SimpleGeneratorsControl()
    {
        InitializeComponent();
        generationOperationCombo.SelectedIndex = 0;
    }

    private void createTimingPointsButton_Click(object sender, EventArgs e)
    {
        CreateTimingPoints();
    }

    private void CreateTimingPoints()
    {
        var options = new LinearBpmScalingTimingPointCreator.Options
        {
            StartOffset = (double)startOffsetNumeric.Value,
            EndOffset = (double)endOffsetNumeric.Value,
            BaseBpm = (double)baseBpmNumeric.Value,
            BpmStep = (double)bpmStepNumeric.Value,
            StepNominator = (int)bpmChangeNominatorNumeric.Value,
            StepDenominator = (int)bpmChangeDenominatorNumeric.Value,
        };
        var creator = new LinearBpmScalingTimingPointCreator(options);
        var points = creator.CreateTimingPoints();

        var encodedTimingPoints = BeatmapEncoder.TimingPoints(points.TimingPoints);
        outputTimingPointsText.Text = string.Join(
            Environment.NewLine,
            encodedTimingPoints);
    }
}