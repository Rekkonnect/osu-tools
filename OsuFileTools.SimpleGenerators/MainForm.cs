using OsuParsers.Beatmaps.Objects;
using OsuParsers.Encoders;
using OsuTools.Common;

namespace OsuFileTools.SimpleGenerators;

public partial class MainForm : Form
{
    public MainForm()
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

public sealed class LinearBpmScalingTimingPointCreator(
    LinearBpmScalingTimingPointCreator.Options options)
{
    private readonly Options _options = options;

    public TimingPointList CreateTimingPoints()
    {
        var currentOffset = _options.StartOffset;
        var currentBpm = _options.BaseBpm;

        var points = new TimingPointList();

        while (currentOffset < _options.EndOffset && currentBpm > 0)
        {
            var bpm = currentBpm;
            var beatLength = BeatLength.FromBpm(bpm).Length * 1000;

            var timingPoint = new TimingPoint
            {
                Offset = currentOffset,
                BeatLength = beatLength,
            };
            points.TimingPoints.Add(timingPoint);

            var normalizationTimingPoint = TimingPointFactory.CreateSV(_options.BaseBpm / bpm);
            normalizationTimingPoint.Offset=  currentOffset;
            points.TimingPoints.Add(normalizationTimingPoint);

            var timingDuration = _options.StepNominator / (double)_options.StepDenominator * 4;

            currentOffset += timingDuration * beatLength;
            currentBpm += _options.BpmStep;
        }

        return points;
    }

    public sealed class Options
    {
        public double StartOffset;
        public double EndOffset;
        public double BaseBpm;
        public double BpmStep;
        public int StepNominator;
        public int StepDenominator;
    }
}
