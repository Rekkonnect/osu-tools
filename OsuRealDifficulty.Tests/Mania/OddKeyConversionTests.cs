using OsuRealDifficulty.Mania;
using System.Text;

namespace OsuRealDifficulty.Tests.Mania;

public sealed class OddKeyConversionTests
{
    [Test]
    public void Basic7K()
    {
        const string chordString = """
            |-  -   |
            | - -   |
            |  --   |
            |   --  |
            |   - - |
            |   -  -|
            |   -   |
            """;

        const string convertedChordString = """
            |-   -   |
            | - -    |
            |  - -   |
            |   - -  |
            |    - - |
            |   -   -|
            |    -   |
            """;

        AssertChordListConversion(chordString, convertedChordString);
    }

    [Test]
    public void MiddleNotAlwaysOccupied7K()
    {
        const string chordString = """
            |-  -   |
            | -     |
            |  -    |
            |   --  |
            |   - - |
            |      -|
            |   -   |
            """;

        const string convertedChordString = """
            |-  -    |
            | -      |
            |  -     |
            |    --  |
            |   -  - |
            |       -|
            |    -   |
            """;

        AssertChordListConversion(chordString, convertedChordString);
    }

    [Test]
    public void MiddleWithLN7K()
    {
        const string chordString = """
            |-  ^   |
            | - |   |
            |  -|   |
            |   |-  |
            |   | - |
            |   |  -|
            |   -   |
            """;

        const string convertedChordString = """
            |-   ^   |
            | -  |   |
            |  - |   |
            |    |-  |
            |    | - |
            |    |  -|
            |    -   |
            """;

        AssertChordListConversion(chordString, convertedChordString);
    }

    [Test]
    public void MiddleWithRiceLNMix7K()
    {
        const string chordString = """
            |-  ^   |
            | - -   |
            |  --   |
            |   ^-  |
            |   | - |
            |   |  -|
            |   -   |
            """;

        const string convertedChordString = """
            |-   ^   |
            | -  -   |
            |  --    |
            |    ^-  |
            |    | - |
            |    |  -|
            |    -   |
            """;

        AssertChordListConversion(chordString, convertedChordString);
    }

    [Test]
    public void Basic1K()
    {
        const string chordString = """
            |-|
            |-|
            |-|
            |-|
            |-|
            |-|
            |-|
            """;

        const string convertedChordString = """
            | -|
            |- |
            | -|
            |- |
            | -|
            |- |
            | -|
            """;

        AssertChordListConversion(chordString, convertedChordString);
    }

    private void AssertChordListConversion(
        string sourceChordString,
        string convertedChordString)
    {
        var chordList = ChordListParsing.Parse(sourceChordString);
        var expectedConverted = ChordListParsing.Parse(convertedChordString);

        var actualConverted = OddKeyNormalization.NormalizeWithAlternateHands(chordList);
        AssertEqualChordLists(expectedConverted, actualConverted);
    }

    // TODO: Move this somewhere that might be useful
    private static void AssertEqualChordLists(
        ChordList expected, ChordList? actual)
    {
        Assert.That(actual!.Keys, Is.EqualTo(expected.Keys), "Mismatching key count");

        int keys = expected.Keys;

        int expectedCount = expected.Chords.Length;
        int actualCount = actual.Chords.Length;

        if (actualCount != expectedCount)
        {
            var formattedActualChords = FormatEntireChordList(actual, keys);
            var failMessage = $"""
                Expected count: {expectedCount}, actual count: {actualCount}

                Actual chords:
                {formattedActualChords}
                """;

            Assert.Fail(failMessage);
            return;
        }

        var areEqual = actual.Chords.SequenceEqual(expected.Chords);
        if (!areEqual)
        {
            var formattedActualChords = FormatEntireChordList(actual, keys);
            var differences = new StringBuilder();

            for (int i = 0; i < actualCount; i++)
            {
                var currentExpected = expected.Chords[i];
                var currentActual = actual.Chords[i];
                bool equals = currentExpected.Equals(currentActual);
                if (!equals)
                {
                    differences.AppendLine($"""
                        Index {i}
                        - {currentExpected.ToString(keys)}
                        + {currentActual.ToString(keys)}

                        """);
                }
            }

            var failMessage = $"""
                Equality comparison failed -- counts were equal

                Actual chords:
                {formattedActualChords}
                Differences:
                {differences}
                """;

            Assert.Fail(failMessage);
        }
    }

    private static string FormatEntireChordList(ChordList list, int keys)
    {
        var chords = list.Chords;
        if (chords.Length is 0)
            return """
                <Empty chord list>
                """;

        var builder = new StringBuilder();

        for (int i = 0; i < chords.Length; i++)
        {
            var formattedChord = chords[i].ToString(keys);
            builder.AppendLine(formattedChord);
        }
        return builder.ToString();
    }
}
