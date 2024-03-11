namespace OsuRealDifficulty.Mania;

public record ChordGapPatternAnnotation(int OffsetStart, int OffsetEnd, int GapSize)
    : IPattern
{
    public MapAnnotationType Type => MapAnnotationType.ChordGap;

    public int TimeDistance => OffsetEnd - OffsetStart;
}
