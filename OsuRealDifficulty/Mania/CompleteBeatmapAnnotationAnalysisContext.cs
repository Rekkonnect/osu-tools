namespace OsuRealDifficulty.Mania;

public readonly struct CompleteBeatmapAnnotationAnalysisContext
{
    public required ManiaBeatmapInfo BeatmapInfo { get; init; }
    public required IList<IMapAnnotation> SourceChordListAnnotations { get; init; }
    public required IList<IMapAnnotation>? NormalizedChordListAnnotations { get; init; }

    public required IReadOnlyTypeKeyedList<IMapAnnotation>
        CommittedSourceChordListAnnotations { get; init; }
    public required IReadOnlyTypeKeyedList<IMapAnnotation>?
        CommittedNormalizedChordListAnnotations { get; init; }

    public required CancellationToken CancellationToken { get; init; }

    public BeatmapAnnotationAnalysisContext ContextForSourceChordList()
    {
        return new()
        {
            BeatmapInfo = BeatmapInfo,
            AffectedChordList = BeatmapInfo.ChordListInfo,
            Annotations = SourceChordListAnnotations,
            CommittedAnnotations = CommittedSourceChordListAnnotations,
            CancellationToken = CancellationToken,
        };
    }
    public BeatmapAnnotationAnalysisContext? ContextForNormalizedChordList()
    {
        // If no normalized chord list exists, we have no context to return
        if (BeatmapInfo.NormalizedChordList is null)
            return null;

        return new()
        {
            BeatmapInfo = BeatmapInfo,
            AffectedChordList = BeatmapInfo.NormalizedChordListInfo!,
            Annotations = NormalizedChordListAnnotations!,
            CommittedAnnotations = CommittedNormalizedChordListAnnotations!,
            CancellationToken = CancellationToken,
        };
    }

    public void GetChordListSpecificContexts(
        out BeatmapAnnotationAnalysisContext sourceChordListContext,
        out BeatmapAnnotationAnalysisContext? normalizedChordListContext)
    {
        sourceChordListContext = ContextForSourceChordList();
        normalizedChordListContext = ContextForNormalizedChordList();
    }
}
