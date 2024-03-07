namespace OsuRealDifficulty.Mania;

public readonly struct BeatmapAnnotationAnalysisContext
{
    public required ManiaBeatmapInfo BeatmapInfo { get; init; }
    public required ChordListInfo AffectedChordList { get; init; }
    public required IList<IMapAnnotation> Annotations { get; init; }

    public required IReadOnlyTypeKeyedList<IMapAnnotation> CommittedAnnotations { get; init; }

    public required CancellationToken CancellationToken { get; init; }

    public void AddAnnotation(IMapAnnotation annotation)
    {
        Annotations.Add(annotation);
    }
}
