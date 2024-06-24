using OsuParsers.Beatmaps.Objects;
using OsuTools.Common;

namespace OsuFileTools.Core;

public class PolyrhythmTimingPointCreator
{
    public TimingPointList CreateTimingPoints(
        IReadOnlyList<PolyrhythmSection> sections,
        Options options)
    {
        var list = new TimingPointList();

        // unoptimized because of the list content migration
        foreach (var section in sections)
        {
            var inner = CreateTimingPoints(section, options);
            list.TimingPoints.AddRange(inner.TimingPoints);
        }

        return list;
    }

    public TimingPointList CreateTimingPoints(
        PolyrhythmSection section,
        Options options)
    {
        var measureLength = section.BeatLength.Length * section.TimeSignature.Nominator;

        var result = new TimingPointList();
        TimingPoint? previousParent = null;

        double offset = section.Offset;

        foreach (var measure in section.Measures)
        {
            CreateForMeasure(measure);
        }

        return result;

        void CreateForMeasure(PolyrhythmMeasure measure)
        {
            foreach (var phrase in measure.Phrases)
            {
                CreateForPhrase(phrase);
            }
        }

        void CreateForPhrase(BasePolyrhythmPhrase phrase)
        {
            var phraseLength = measureLength * phrase.QuantizedRhythmicalValue.Ratio;
            var noteLength = phraseLength / phrase.PolyValue;
            var beatLength = noteLength * options.NoteBeatDivisor;

            var previousParentLength = previousParent?.BeatLength().Length;
            if (beatLength != previousParentLength)
            {
                TimingPointFactory.CreateWithNormalization(
                    new BeatLength(beatLength),
                    options.NormalizedBeatLength,
                    out var parent,
                    out var normalizer);

                int intOffset = (int)offset;
                parent.Offset = intOffset;
                normalizer.Offset = intOffset;

                result.TimingPoints.Add(parent);
                result.TimingPoints.Add(normalizer);
            }

            offset += phraseLength * 1000;
        }
    }

    public sealed class Options
    {
        public required BeatLength NormalizedBeatLength;
        public required int NoteBeatDivisor;
    }
}
