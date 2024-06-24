using OsuFileTools.Core;
using OsuTools.Common;

namespace OsuFileTools.Tests;

public class PolyrhythmParsingTests
{
    [Theory]
    public void SourceTest(
        [
            Values([
                Sources.Polyrhythms.Tpazolite_ChaosInTheDark,
            ]),
        ]
        string source)
    {
        // just validate that parsing is valid
        var parsed = PolyrhythmSectionParser.Parse(source);
        Assert.That(parsed.Count > 0);
    }

    [Test]
    [Ignore("Constructing the exact parsed content is tedious")]
    public void PolyTest()
    {
        const string source = Sources.Polyrhythms.Tpazolite_ChaosInTheDark;
        var fourFour = new RhythmicalValue(4, 4);
        var sections = PolyrhythmSectionParser.Parse(source);

        var expectedMeasures = new[]
        {
            PolyrhythmMeasure.FromPhrases([
                new SimplePolyrhythmPhrase(4, 3, 8),
                new SimplePolyrhythmPhrase(2, 2, 16),
                new ComplexPolyrhythmPhrase(2, 2, 8, [
                        new PhraseNote(2, 0, false),
                        new PhraseNote(2, 0, false),
                        new PhraseNote(1, 0, false),
                    ]),
                new SimplePolyrhythmPhrase(2, 2, 8),
            ]),

            PolyrhythmMeasure.FromPhrases([
                new SimplePolyrhythmPhrase(4, 3, 8),
                new SimplePolyrhythmPhrase(2, 2, 16),
                new SimplePolyrhythmPhrase(3, 2, 16),
                new SimplePolyrhythmPhrase(2, 2, 16),
                new SimplePolyrhythmPhrase(1, 1, 4),
            ]),

            // Good fucking luck denoting the rest
        };

        var expectedSection = new PolyrhythmSection(
            54652,
            BeatLength.FromBpm(165),
            fourFour);

        var expectedSections = new[] {
            expectedSection,
        };

        foreach (var measure in expectedMeasures)
        {
            expectedSection.AddMeasure(measure);
        }

        Assert.AreEqual(expectedSections, sections);
    }
}
