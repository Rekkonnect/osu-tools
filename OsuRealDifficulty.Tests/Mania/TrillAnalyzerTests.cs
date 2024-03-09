using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.Tests.Mania;

public class TrillAnalyzerTests : FullBeatmapAnalyzerTests<TrillPatternAnalyzer>
{
    protected override TrillPatternAnalyzer DefaultAnalyzer
        => TrillPatternAnalyzer.Instance;

    #region Annotations

    [Test]
    public void BasicTrill()
    {
        const string map = """
            |-   | 75
            | -  | 50
            |-   | 25
            | -  | 0
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 75, 4, Press("--  ")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void JumpTrills()
    {
        const string map = """
            |  --| 275
            |--  | 250
            |  --| 225
            |--  | 200
            |- - | 175
            | - -| 150
            |- - | 125
            | - -| 100
            |-  -| 75
            | -- | 50
            |-  -| 25
            | -- | 0
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 75, 8, Press("----")),
            new TrillPattern(100, 175, 8, Press("----")),
            new TrillPattern(200, 275, 8, Press("----")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void NotAllTrills()
    {
        const string map = """
            |- --| 275
            | -  | 250
            |  - | 225
            |--  | 200
            |  - | 175
            | - -| 150
            |- - | 125
            | -  | 100
            |-  -| 75
            | -  | 50
            |-  -| 25
            |  - | 0
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(25, 100, 6, Press("-- -")),
            new TrillPattern(125, 275, 7, Press(" -- ")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void FakeTrills()
    {
        const string map = """
            |  - | 700
            |-   | 600
            |   -| 500
            |-   | 400
            |  - | 300
            |-   | 250
            | -  | 200
            |-   | 150
            |  - | 100
            |-   | 50
            |   -| 25
            |-   | 0
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 50, 3, Press("-  -")),
            new TrillPattern(150, 250, 3, Press("--  ")),
            new TrillPattern(400, 600, 3, Press("-  -")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void MinTrillLengthEnd()
    {
        const string map = """
            |-   | 600
            |   -| 500
            |-   | 400
            |  - | 300
            |-   | 250
            | -  | 200
            |-   | 150
            |  - | 100
            |-   | 50
            |   -| 25
            |-   | 0
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 50, 3, Press("-  -")),
            new TrillPattern(150, 250, 3, Press("--  ")),
            new TrillPattern(400, 600, 3, Press("-  -")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void OnlyLongTrill()
    {
        const string map = """
            |   -|
            |-   |
            |   -|
            |-   |
            |   -|
            |-   |
            |   -|
            |-   |
            |   -|
            |-   |
            |   -|
            |-   |
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 11, 12, Press("-  -")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void OnlyLongTrillExpandingFirst()
    {
        const string map = """
            |   -|
            |--  |
            |   -|
            |--  |
            |   -|
            |--  |
            |   -|
            |--  |
            |   -|
            |--  |
            |   -|
            |-   |
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 11, 12, Press("-  -")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void OnlyLongTrillExpandingFirstSecond()
    {
        const string map = """
            |  --|
            |--  |
            |  --|
            |--  |
            |  --|
            |--  |
            |  --|
            |--  |
            |  --|
            |--  |
            |   -|
            |-   |
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 11, 12, Press("-  -")),
            new TrillPattern(2, 11, 10, Press(" -- ")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void RiceLNTrills()
    {
        const string map = """
            | ^ ^| 510
            | - -| 500
            |^ ^ | 410
            |- - | 400
            | ^ ^| 310
            | - -| 300
            |^ ^ | 210
            |- - | 200
            | ^ ^| 110
            | - -| 100
            |^ ^ | 10
            |- - | 0
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 500, 12, Press("----")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void RiceLNMixTrills()
    {
        const string map = """
            | ^  | 510
            | - -| 500
            |^   | 410
            |- - | 400
            |   ^| 310
            | - -| 300
            |  ^ | 210
            |- - | 200
            | ^  | 110
            | - -| 100
            |^   | 10
            |- - | 0
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 500, 12, Press("----")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void RiceTillsWhileHolding()
    {
        const string map = """
            | |--|
            |-|  |
            | |--|
            |-|  |
            | |--|
            |-|  |
            | |--|
            |-|  |
            | |--|
            |-|  |
            | |--|
            |--  |
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 11, 18, Press("- --")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void RiceTillsWithInterjectingLN()
    {
        const string map = """
            |  --|
            |-   |
            | ^--|
            |-|  |
            | |--|
            |-|  |
            | |--|
            |-|  |
            | ---|
            |-   |
            |  --|
            |-   |
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 11, 18, Press("- --")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void InterjectingTrills7K()
    {
        const string map = """
            | - --  |
            |-    --|
            | - --  |
            |  -  - |
            |-  --  |
            |  -  --|
            |   --  |
            |-    --|
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 3, 8, Press("   ----")),
            new TrillPattern(2, 4, 3, Press("- -    ")),
            new TrillPattern(4, 7, 8, Press(" - --- ")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void Tempestissimo_CSFinale_FirstPart()
    {
        // Source from map:
        // https://osu.ppy.sh/beatmapsets/1179815#mania/2460194
        const string map = """
            |^ - | 9756
            ||  -| 8977
            || - | 8912
            ||  -| 8847
            || - | 8782
            ||  -| 8717
            || - | 8653
            ||  -| 8588
            || - | 8523
            ||  -| 8458
            || - | 8393
            ||  -| 8328
            || - | 8263
            ||  -| 8198
            || - | 8133
            ||  -| 8068
            || - | 8003
            |-  -| 7938
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(7938, 8977, 17, Press("  --")),
        };

        AssertAnalysis(map, annotations);
    }

    [Test]
    public void SmallTrills()
    {
        const string map = """
            |    | 175
            |-   | 150
            | -  | 125
            |-   | 100
            |    | 75
            | -  | 50
            |-   | 25
            | -  | 0
            """;

        var annotations = new MapAnnotationList
        {
            new TrillPattern(0, 50, 3, Press("--  ")),
            new TrillPattern(100, 150, 3, Press("--  ")),
        };

        AssertAnalysis(map, annotations);
    }

    #endregion

    #region Difficulty

    [Test]
    public void SameBasicTrillFasterDifficultyComparison()
    {
        const string easy = """
            |-   | 750
            | -  | 500
            |-   | 250
            | -  | 0
            """;

        const string hard = """
            |-   | 75
            | -  | 50
            |-   | 25
            | -  | 0
            """;

        AssertComparedDifficulty(easy, hard);
    }

    [Test]
    public void SameSpeedDenserTrillComparison()
    {
        const string easy = """
            |-   | 750
            | -  | 500
            |-   | 250
            | -  | 0
            """;

        const string hard = """
            |-   | 750
            | -- | 500
            |-   | 250
            | -- | 0
            """;

        const string harder = """
            |-   | 750
            | ---| 500
            |-   | 250
            | ---| 0
            """;

        AssertAscendingDifficulty(easy, hard, harder);
    }

    [Test]
    public void SameSpeedPatternMoreKeysComparison()
    {
        const string four = """
            |-   | 750
            | -  | 500
            |-   | 250
            | -  | 0
            """;

        const string seven = """
            |-      | 750
            | -     | 500
            |-      | 250
            | -     | 0
            """;

        AssertEqualDifficulty(four, seven);
    }

    #endregion
}
