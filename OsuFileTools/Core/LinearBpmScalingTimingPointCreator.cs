﻿using OsuParsers.Beatmaps.Objects;
using OsuTools.Common;

namespace OsuFileTools.Core;

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
            var beatMs = BeatLength.FromBpm(bpm).Seconds * 1000;

            var timingPoint = new TimingPoint
            {
                Offset = currentOffset,
                BeatLength = beatMs,
            };
            points.TimingPoints.Add(timingPoint);

            var normalizationTimingPoint = TimingPointFactory.CreateSV(_options.BaseBpm / bpm);
            normalizationTimingPoint.Offset = currentOffset;
            points.TimingPoints.Add(normalizationTimingPoint);

            var timingDuration = _options.StepNominator / (double)_options.StepDenominator * 4;

            currentOffset += timingDuration * beatMs;
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
