namespace OsuRealDifficulty.Mania;

public record ChordGapAnnotation(int Offset, int GapSize)
    : IMapAnnotation
{
    public MapAnnotationType Type => MapAnnotationType.ChordGap;
}
