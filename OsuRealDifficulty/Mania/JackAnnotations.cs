namespace OsuRealDifficulty.Mania;

internal sealed record JackAnnotations(
    IReadOnlyList<MinijackAnnotation> Minijacks,
    IReadOnlyList<AnchorPattern> Anchors);
