namespace OsuRealDifficulty.Mania;

// TODO: Into record or struct?
// TODO: Chord[] into Memory<Chord>
public class ChordList(int keys, Chord[] chords)
{
    public readonly int Keys = keys;
    public readonly Chord[] Chords = chords;
    public readonly ReadOnlyMemory<Chord> ChordMemory = chords;

    public bool IsOddKey => Keys.IsOdd();
    public bool IsEvenKey => !IsOddKey;
}
