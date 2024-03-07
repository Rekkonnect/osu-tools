using Garyon.Extensions;
using OsuRealDifficulty.Mania;
using System.Collections.Specialized;
using System.Text;

namespace OsuRealDifficulty.Tests.Mania;

public abstract class BeatmapAnalyzerTests<T> : BeatmapAnalyzerTests
    where T : class, IBeatmapAnnotationAnalyzer
{
    protected override T? DefaultAnalyzer => null;

    [Test]
    public void EmptyChordList()
    {
        IgnoreWhenNoDefaultAnalyzer();

        for (int i = 1; i <= ChordNotesFacts.MaxColumns; i++)
        {
            var emptyChordList = new ChordList(i, []);
            AssertEmptyAnalysis(emptyChordList);
        }
    }

    [Test]
    public void EmptyField()
    {
        IgnoreWhenNoDefaultAnalyzer();

        const int emptyChordCount = 10;
        var chords = new Chord[emptyChordCount];
        for (int i = 0; i < emptyChordCount; i++)
        {
            chords[i] = new Chord
            {
                Offset = i * 2,
                Notes = new(),
            };
        }

        for (int i = 1; i <= ChordNotesFacts.MaxColumns; i++)
        {
            var emptyChordList = new ChordList(i, chords);
            AssertEmptyAnalysis(emptyChordList);
        }
    }

    protected void IgnoreWhenNoDefaultAnalyzer()
    {
        if (DefaultAnalyzer is null)
        {
            Assert.Ignore();
        }
    }

    protected void AssertEmptyAnalysis(ChordList chordList)
    {
        AssertAnalysis(chordList, []);
    }
}

public abstract class BeatmapAnalyzerTests
{
    protected virtual IBeatmapAnnotationAnalyzer? DefaultAnalyzer => null;

    protected static void AssertAnnotationListsEqual(
        MapAnnotationList expected,
        MapAnnotationList actual,
        bool sortAnnotationLists,
        int keys)
    {
        int expectedCount = expected.Count;
        int actualCount = actual.Count;
        if (expectedCount != actualCount)
        {
            var formattedActualAnnotations = FormatAllAnnotations(actual, keys);
            var failMessage = $"""
                Expected count: {expectedCount}, actual count: {actualCount}

                Actual annotations:
                {formattedActualAnnotations}
                """;

            Assert.Fail(failMessage);
        }

        bool areEqual = expected.AreEqualSorted(actual, sortAnnotationLists);
        if (!areEqual)
        {
            var formattedActualAnnotations = FormatAllAnnotations(actual, keys);
            var differences = new StringBuilder();

            for (int i = 0; i < expectedCount; i++)
            {
                var currentExpected = expected[i];
                var currentActual = actual[i];
                bool equals = currentExpected.Equals(currentActual);
                if (!equals)
                {
                    differences.AppendLine($"""
                        Index {i}
                        - {MapAnnotationFormatting.FormatAnnotation(currentExpected, keys)}
                        + {MapAnnotationFormatting.FormatAnnotation(currentActual, keys)}

                        """);
                }
            }

            var failMessage = $"""
                Equality comparison failed -- counts were equal

                Actual annotations:
                {formattedActualAnnotations}
                Differences:
                {differences}
                """;

            Assert.Fail(failMessage);
        }
        Assert.That(areEqual, Is.True, "Equality comparison failed -- counts were equal");
    }

    private static string FormatAllAnnotations(MapAnnotationList list, int keys)
    {
        if (list.Count is 0)
            return """
                new MapAnnotationList()
                """;

        var builder = new StringBuilder();

        builder.Append("""
            new MapAnnotationList
            {

            """);
        for (int i = 0; i < list.Count; i++)
        {
            const string indentation = "    ";
            var annotation = MapAnnotationFormatting.FormatAnnotation(list[i], keys);
            builder.Append(indentation);
            builder.Append(annotation);
            builder.AppendLine(',');
        }
        builder.Append('}');
        return builder.ToString(); 
    }

    protected void AssertAnalysis(
        string chordListString,
        MapAnnotationList expectedAnnotations)
    {
        var chordList = ChordListParsing.Parse(chordListString);
        AssertAnalysis(chordList, expectedAnnotations);
    }

    protected void AssertAnalysis(
        string chordListString,
        string normalizedChordListString,
        MapAnnotationList expectedAnnotations)
    {
        var chordList = ChordListParsing.Parse(chordListString);
        var normalizedChordList = ChordListParsing.Parse(normalizedChordListString);
        AssertAnalysis(chordList, normalizedChordList, expectedAnnotations);
    }

    protected void AssertAnalysis(
        ChordList chordList,
        MapAnnotationList expectedAnnotations)
    {
        var driver = DriverWithOnlyChordList(chordList);
        AssertAnalysis(driver, expectedAnnotations);
    }

    protected void AssertAnalysis(
        ChordList chordList,
        ChordList? normalizedChordList,
        MapAnnotationList expectedAnnotations)
    {
        var driver = DriverWithOnlyChordLists(chordList, normalizedChordList);
        AssertAnalysis(driver, expectedAnnotations);
    }

    protected void AssertAnalysis(
        SingleBeatmapAnalyzerTestDriver driver,
        MapAnnotationList expectedAnnotations)
    {
        driver.Execute();
        int keys = driver.BeatmapInfo.ChordList.Keys;
        var actualAnnotations = driver.SourceChordListAnnotations;
        AssertAnnotationListsEqual(
            expectedAnnotations,
            actualAnnotations,
            true,
            keys);
    }

    protected SingleBeatmapAnalyzerTestDriver DriverWithOnlyChordListString(
        string chordListString)
    {
        var chordList = ChordListParsing.Parse(chordListString);
        return DriverWithOnlyChordList(chordList);
    }

    protected SingleBeatmapAnalyzerTestDriver DriverWithOnlyChordListStrings(
        string chordListString,
        string normalizedChordListString)
    {
        var chordList = ChordListParsing.Parse(chordListString);
        var normalizedChordList = ChordListParsing.Parse(normalizedChordListString);
        return DriverWithOnlyChordLists(chordList, normalizedChordList);
    }

    protected SingleBeatmapAnalyzerTestDriver DriverWithOnlyChordList(ChordList list)
    {
        return SingleBeatmapAnalyzerTestDriver.CreateWithOnlyChordList(
            list,
            DefaultAnalyzer!);
    }

    protected SingleBeatmapAnalyzerTestDriver DriverWithOnlyChordLists(
        ChordList list,
        ChordList? normalizedChordList)
    {
        return SingleBeatmapAnalyzerTestDriver.CreateWithOnlyChordLists(
            list,
            normalizedChordList,
            DefaultAnalyzer!);
    }

    protected void AssertExecuteWithValidCalculationResult(SingleBeatmapAnalyzerTestDriver driver)
    {
        driver.Execute();
        var value = driver.CalculationResult;
        Assert.That(value.IsValid, Is.True);
    }

    protected BitVector32 Press(string pressString)
    {
        int value = 0;

        for (int i = 0; i < pressString.Length; i++)
        {
            if (pressString[i] is '-')
            {
                value |= 1 << i;
            }
        }

        return new(value);
    }
}
