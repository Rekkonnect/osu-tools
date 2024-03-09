using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.Tests;

public sealed class SingleBeatmapDifficultyAnalyzerTestDriver(
    ManiaBeatmapInfo beatmapInfo,
    IBeatmapDifficultyAnalyzer analyzer)
    : SingleBeatmapAnalyzerTestDriver(beatmapInfo, analyzer)
{
    public IBeatmapDifficultyAnalyzer Analyzer { get; } = analyzer;

    public CalculationResult CalculationResult { get; private set; } = CalculationResult.Pending;

    public override Task Execute(CancellationToken cancellationToken = default)
    {
        base.Execute(cancellationToken);
        CalculationResult = Analyzer.CalculationResultRef(AnalyzedDifficulty);
        return Task.CompletedTask;
    }

    public static SingleBeatmapDifficultyAnalyzerTestDriver CreateWithOnlyChordList(
        ChordList chordList,
        IBeatmapDifficultyAnalyzer analyzer)
    {
        return CreateWithOnlyChordLists(chordList, null, analyzer);
    }
    public static SingleBeatmapDifficultyAnalyzerTestDriver CreateWithOnlyChordLists(
        ChordList chordList,
        ChordList? normalizedChordList,
        IBeatmapDifficultyAnalyzer analyzer)
    {
        var info = ManiaBeatmapInfoConstruction.Instance
            .CreateInfoForChordListWithNormalization(
                chordList, normalizedChordList);

        return new(info, analyzer);
    }
}
