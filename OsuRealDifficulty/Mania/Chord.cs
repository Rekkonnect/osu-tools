using System.Diagnostics;

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
}
