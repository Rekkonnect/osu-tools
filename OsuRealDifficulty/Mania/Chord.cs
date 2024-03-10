namespace OsuRealDifficulty.Mania;

[DebuggerDisplay($"{{{nameof(DebuggerDisplay)}(),nq}}")]
public struct Chord
{
    public int Offset;
    public ChordNotes Notes;

    public readonly string DebuggerDisplay()
    {
        return ToString(ChordNotesFacts.MaxColumns);
    }

    public readonly string ToString(int keys)
    {
        return $"{Notes.ToString(keys)} {Offset}";
    }

    public static Chord WithOffset(int offset)
    {
        return new()
        {
            Offset = offset,
        };
    }

    public sealed class AscendingOffsetComparer : IComparer<Chord>
    {
        public static AscendingOffsetComparer Instance { get; } = new();

        public int Compare(Chord x, Chord y)
        {
            return x.Offset.CompareTo(y.Offset);
        }
    }
}
