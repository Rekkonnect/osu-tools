using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.Tests;

public class SingleBeatmapAnalyzerTestDriver(
    ManiaBeatmapInfo beatmapInfo,
    IBeatmapAnalyzer analyzer)
    : BaseBeatmapAnalyzerDriver
{
    public readonly MapAnnotationList SourceChordListAnnotations = [];
    public readonly MapAnnotationList NormalizedChordListAnnotations = [];

    public ManiaBeatmapInfo BeatmapInfo { get; } = beatmapInfo;

    public override Task Execute(CancellationToken cancellationToken = default)
    {
        var completeContext = new CompleteBeatmapAnnotationAnalysisContext
        {
            BeatmapInfo = BeatmapInfo,
            CommittedSourceChordListAnnotations = null!,
            CommittedNormalizedChordListAnnotations = null!,
            SourceChordListAnnotations = SourceChordListAnnotations,
            NormalizedChordListAnnotations = NormalizedChordListAnnotations,
            CancellationToken = cancellationToken,
            AnalyzerDiagnostics = new(),
        };

        // Perform analysis
        AnalyzeAny(analyzer, completeContext);
        return Task.CompletedTask;
    }

    public static SingleBeatmapAnalyzerTestDriver CreateWithOnlyChordList(
        ChordList chordList,
        IBeatmapAnalyzer analyzer)
    {
        return CreateWithOnlyChordLists(chordList, null, analyzer);
    }
    public static SingleBeatmapAnalyzerTestDriver CreateWithOnlyChordLists(
        ChordList chordList,
        ChordList? normalizedChordList,
        IBeatmapAnalyzer analyzer)
    {
        var info = ManiaBeatmapInfoConstruction.Instance
            .CreateInfoForChordListWithNormalization(
                chordList, normalizedChordList);

        return new(info, analyzer);
    }
}
