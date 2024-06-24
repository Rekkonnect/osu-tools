using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.Tests.Mania;

public class SinglestreamAnalyzerTests : FullBeatmapAnalyzerTests<SinglestreamPatternAnalyzer>
{
    protected override SinglestreamPatternAnalyzer DefaultAnalyzer
        => SinglestreamPatternAnalyzer.Instance;

    #region Annotations

    [Test]
    public void BasicSinglestream()
    {
        const string map = """
            |   -| 75
            |  - | 50
            | -  | 25
            |-   | 0
            """;

        var annotations = new MapAnnotationList
        {
            new SinglestreamPattern(0, 75, 4, 4, 3),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void SinglestreamMixedWithChordstreams()
    {
        const string map = """
            |   -| 175
            |- - | 150
            | -  | 125
            |- - | 100
            |   -| 75
            |  - | 50
            | -  | 25
            |-  -| 0
            """;

        var annotations = new MapAnnotationList
        {
            new SinglestreamPattern(25, 75, 3, 3, 2),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void StaircaseSinglestream()
    {
        const string map = """
            |   -| 175
            |-   | 150
            | -  | 125
            |  - | 100
            |   -| 75
            |  - | 50
            | -  | 25
            |-   | 0
            """;

        var annotations = new MapAnnotationList
        {
            new SinglestreamPattern(0, 175, 8, 4, 9),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void DistantTrillSinglestream()
    {
        const string map = """
            |   -| 175
            |-   | 150
            |   -| 125
            |-   | 100
            |   -| 75
            |-   | 50
            |   -| 25
            |-   | 0
            """;

        var annotations = new MapAnnotationList
        {
            new SinglestreamPattern(0, 175, 8, 2, 21),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void AnchorSinglestream()
    {
        const string map = """
            |-  -| 175
            |-   | 150
            |-   | 125
            |-   | 100
            |- --| 75
            |-   | 50
            |-   | 25
            |-   | 0
            """;

        var annotations = new MapAnnotationList
        {
            new SinglestreamPattern(0, 50, 3, 1, 0),
            new SinglestreamPattern(100, 150, 3, 1, 0),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void SinglestreamWithMinijacks()
    {
        const string map = """
            | -  | 375
            |  - | 350
            |-   | 325
            |-   | 300
            |  - | 275
            |   -| 250
            |-   | 225
            |-   | 200
            |   -| 175
            |  - | 150
            |-   | 125
            |-   | 100
            |  - | 75
            | -  | 50
            |-   | 25
            |-   | 0
            """;

        var annotations = new MapAnnotationList
        {
            new SinglestreamPattern(0, 375, 16, 4, 19),
        };

        AssertAnalysis(map, annotations);
    }

    #endregion

    #region Difficulty

    [Test]
    public void SameBasicSinglestreamFasterDifficultyComparison()
    {
        const string easy = """
            |   -| 750
            |  - | 500
            | -  | 250
            |-   | 0
            """;

        const string hard = """
            |   -| 75
            |  - | 50
            | -  | 25
            |-   | 0
            """;

        AssertComparedDifficulty(easy, hard);
    }

    [Test]
    public void SameSpeedMoreDistantSinglestreamDifficultyComparison()
    {
        const string easy = """
            |   -| 750
            |  - | 500
            | -  | 250
            |-   | 0
            """;

        const string hard = """
            |  - | 750
            | -  | 500
            |   -| 250
            |-   | 0
            """;

        AssertComparedDifficulty(easy, hard);
    }

    [Test]
    public void SamePatternMoreLengthSinglestreamDifficultyComparison()
    {
        const string easy = """
            |   -| 75
            |  - | 50
            | -  | 25
            |-   | 0
            """;

        const string hard = """
            |   -| 475
            |  - | 450
            | -  | 425
            |-   | 400
            |   -| 375
            |  - | 350
            | -  | 325
            |-   | 300
            |   -| 275
            |  - | 250
            | -  | 225
            |-   | 200
            |   -| 175
            |  - | 150
            | -  | 125
            |-   | 100
            |   -| 75
            |  - | 50
            | -  | 25
            |-   | 0
            """;

        AssertComparedDifficulty(easy, hard);
    }

    #endregion
}
