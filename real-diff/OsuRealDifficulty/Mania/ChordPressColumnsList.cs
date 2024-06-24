namespace OsuRealDifficulty.Mania;

public class ChordPressColumnsList : List<ChordPressColumns>
{
    public ChordPressColumnsList() { }

    public ChordPressColumnsList(int capacity)
        : base(capacity) { }

    public void DeconstructLists(out Chord[] chords, out BitVector32[] pressColumns)
    {
        int count = Count;
        chords = new Chord[count];
        pressColumns = new BitVector32[count];

        for (int i = 0; i < count; i++)
        {
            var current = this[i];
            chords[i] = current.Chord;
            pressColumns[i] = current.PressColumns;
        }
    }
}
