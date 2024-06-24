using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.Tests.Mania;

public sealed class HandOccupationConversionTests
{
    [Test]
    public void Anchor4K()
    {
        const string map = """
            |- - | 750
            |-  -| 625
            |- - | 500
            |--  | 375
            |- - | 250
            |-  -| 125
            |-   | 0
            """;

        var expectedOccupations = new HandOccupationList
        {
            new(0, HandState.PressFinger, HandState.Void),
            new(125, HandState.PressFinger, HandState.PressFinger),
            new(250, HandState.PressFinger, HandState.FingerHit),
            new(375, HandState.PressFinger, HandState.Void),
            new(500, HandState.PressFinger, HandState.PressFinger),
            new(625, HandState.PressFinger, HandState.FingerHit),
            new(750, HandState.PressFinger, HandState.PressFinger),
        };

        AssertHandOccupations(map, expectedOccupations);
    }

    [Test]
    public void RegularHandstream4K()
    {
        const string map = """
            | -- | 750
            |   -| 625
            |--- | 500
            |   -| 375
            |- - | 250
            | -  | 125
            |- --| 0
            """;

        var expectedOccupations = new HandOccupationList
        {
            new(0, HandState.PressFinger, HandState.PressFinger),
            new(125, HandState.FingerHit, HandState.Void),
            new(250, HandState.PressFinger, HandState.PressFinger),
            new(375, HandState.Void, HandState.FingerHit),
            new(500, HandState.PressFinger, HandState.PressFinger),
            new(625, HandState.Void, HandState.FingerHit),
            new(750, HandState.PressFinger, HandState.PressFinger),
        };

        AssertHandOccupations(map, expectedOccupations);
    }

    [Test]
    public void RegularBrackets6K()
    {
        const string map = """
            |-- -- | 750
            |  -  -| 625
            |   -- | 500
            |---  -| 375
            |    - | 250
            |- --  | 125
            | -  --| 0
            """;

        var expectedOccupations = new HandOccupationList
        {
            new(0, HandState.PressFinger, HandState.PressFinger),
            new(125, HandState.FingerHit, HandState.FingerHit),
            new(250, HandState.Void, HandState.PressFinger),
            new(375, HandState.PressFinger, HandState.FingerHit),
            new(500, HandState.Void, HandState.PressFinger),
            new(625, HandState.PressFinger, HandState.FingerHit),
            new(750, HandState.FingerHit, HandState.PressFinger),
        };

        AssertHandOccupations(map, expectedOccupations);
    }

    private static void AssertHandOccupations(
        string chordListString, HandOccupationList expectedOccupations)
    {
        var chordList = ChordListParsing.Parse(chordListString);
        var actualOccupations = HandOccupationCalculation.GetHandOccupations(chordList);
        AssertEqualHandOccupations(actualOccupations, expectedOccupations);
    }

    private static void AssertEqualHandOccupations(
        HandOccupationList actualOccupations, HandOccupationList expectedOccupations)
    {
        bool areEqual = actualOccupations.SequenceEqual(expectedOccupations);
        if (areEqual)
        {
            return;
        }

        var actualFormatted = HandOccupationEventFormatting.FormatAll(actualOccupations);

        if (actualOccupations.Count != expectedOccupations.Count)
        {
            var message = $"""
                Count mismatch
                Expected count: {expectedOccupations.Count}
                Actual count: {actualOccupations.Count}

                Actual occupations:
                {actualFormatted}
                """;
            Assert.Fail(message);
        }
        else
        {
            var message = $"""
                Expected count matched -- differences found

                Actual occupations:
                {actualFormatted}
                """;
            Assert.Fail(message);
        }
    }
}
