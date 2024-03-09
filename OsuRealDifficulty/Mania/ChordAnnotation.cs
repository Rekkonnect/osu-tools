namespace OsuRealDifficulty.Mania;

public record ChordAnnotation(int Offset, int NoteCount)
    : ISinglePointAnnotation
{
    public MapAnnotationType Type => MapAnnotationType.Chord;
}
