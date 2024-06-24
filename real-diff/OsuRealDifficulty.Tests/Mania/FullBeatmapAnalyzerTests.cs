using Garyon.Extensions;
using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.Tests.Mania;

public abstract class FullBeatmapAnalyzerTests<T> : BeatmapAnalyzerTests<T>
    where T : class, IFullBeatmapAnalyzer
{
    protected void AssertComparedDifficulty(
        string aChordString,
        string bChordString,
        Action<double, double> assertion)
    {
        var driverA = DriverWithOnlyChordListString(aChordString);
        var driverB = DriverWithOnlyChordListString(bChordString);

        AssertExecuteWithValidCalculationResult(driverA);
        AssertExecuteWithValidCalculationResult(driverB);

        var difficultyA = driverA.CalculationResult.Value;
        var difficultyB = driverB.CalculationResult.Value;

        WriteDifficulties(difficultyA, difficultyB);

        assertion(difficultyA, difficultyB);
    }

    protected void AssertAscendingDifficulty(
        params string[] chordStrings)
    {
        var drivers = chordStrings.SelectArray(DriverWithOnlyChordListString);
        drivers.ForEach(AssertExecuteWithValidCalculationResult);
        var difficulties = drivers.SelectArray(driver => driver.CalculationResult.Value);

        WriteDifficulties(difficulties);

        for (int i = 1; i < difficulties.Length; i++)
        {
            Assert.That(difficulties[i], Is.GreaterThan(difficulties[i - 1]));
        }
    }

    protected void WriteDifficulties(params double[] difficulties)
    {
        TestContext.WriteLine($"""
            Calculated difficulty values:
            {string.Join("\r\n", difficulties)}
            """);
    }

    protected void AssertComparedDifficulty(
        string easyChordString,
        string hardChordString)
    {
        AssertComparedDifficulty(easyChordString, hardChordString, Assertion);

        static void Assertion(double easyDifficulty, double hardDifficulty)
        {
            Assert.That(hardDifficulty, Is.GreaterThan(easyDifficulty));
        }
    }

    protected void AssertEqualDifficulty(
        string aChordString,
        string bChordString)
    {
        AssertComparedDifficulty(aChordString, bChordString, Assertion);

        static void Assertion(double easyDifficulty, double hardDifficulty)
        {
            Assert.That(hardDifficulty, Is.EqualTo(easyDifficulty));
        }
    }

    protected void AssertExecuteWithValidCalculationResult(
        SingleBeatmapDifficultyAnalyzerTestDriver driver)
    {
        driver.Execute();
        var value = driver.CalculationResult;
        Assert.That(value.IsValid, Is.True);
    }

#pragma warning disable CS8603 // Possible null reference return.
    protected override SingleBeatmapDifficultyAnalyzerTestDriver DriverWithOnlyChordListString(
        string chordListString)
    {
        return base.DriverWithOnlyChordListString(chordListString)
            as SingleBeatmapDifficultyAnalyzerTestDriver;
    }

    protected override SingleBeatmapDifficultyAnalyzerTestDriver DriverWithOnlyChordListStrings(
        string chordListString,
        string normalizedChordListString)
    {
        return base.DriverWithOnlyChordListString(chordListString)
            as SingleBeatmapDifficultyAnalyzerTestDriver;
    }
#pragma warning restore CS8603 // Possible null reference return.

    protected override SingleBeatmapDifficultyAnalyzerTestDriver DriverWithOnlyChordList(
        ChordList list)
    {
        return SingleBeatmapDifficultyAnalyzerTestDriver.CreateWithOnlyChordList(
            list,
            DefaultAnalyzer!);
    }

    protected override SingleBeatmapDifficultyAnalyzerTestDriver DriverWithOnlyChordLists(
        ChordList list,
        ChordList? normalizedChordList)
    {
        return SingleBeatmapDifficultyAnalyzerTestDriver.CreateWithOnlyChordLists(
            list,
            normalizedChordList,
            DefaultAnalyzer!);
    }
}
