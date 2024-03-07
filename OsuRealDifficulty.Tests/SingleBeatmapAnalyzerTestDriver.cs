using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.Tests;

public sealed class SingleBeatmapAnalyzerTestDriver(
    ManiaBeatmapInfo beatmapInfo,
    IBeatmapAnnotationAnalyzer analyzer)
{
    public readonly MapAnnotationList SourceChordListAnnotations = [];
    public readonly MapAnnotationList NormalizedChordListAnnotations = [];

    public AnalyzedDifficulty AnalyzedDifficulty { get; } = AnalyzedDifficulty.NewPending;
    public CalculationResult CalculationResult { get; private set; } = CalculationResult.Pending;

    public ManiaBeatmapInfo BeatmapInfo { get; } = beatmapInfo;

    public void Execute()
    {
        var completeContext = new CompleteBeatmapAnnotationAnalysisContext
        {
            BeatmapInfo = BeatmapInfo,
            CommittedSourceChordListAnnotations = null!,
            CommittedNormalizedChordListAnnotations = null!,
            SourceChordListAnnotations = SourceChordListAnnotations,
            NormalizedChordListAnnotations = NormalizedChordListAnnotations,
            CancellationToken = CancellationToken.None,
        };

        // Perform analysis
        analyzer.Analyze(completeContext);
        CalculationResult = analyzer.CalculateDifficultyResult(completeContext);
        ref var calculationResultRef = ref analyzer.CalculationResultRef(AnalyzedDifficulty);
        calculationResultRef = CalculationResult;
    }

    public static SingleBeatmapAnalyzerTestDriver CreateWithOnlyChordList(
        ChordList chordList,
        IBeatmapAnnotationAnalyzer analyzer)
    {
        return CreateWithOnlyChordLists(chordList, null, analyzer);
    }
    public static SingleBeatmapAnalyzerTestDriver CreateWithOnlyChordLists(
        ChordList chordList,
        ChordList? normalizedChordList,
        IBeatmapAnnotationAnalyzer analyzer)
    {
        var info = ManiaBeatmapInfoConstructor.Instance
            .CreateInfoForChordListWithNormalization(
                chordList, normalizedChordList);

        return new(info, analyzer);
    }
}
