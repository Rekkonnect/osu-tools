namespace OsuRealDifficulty.Mania;

public sealed class AlternateHandOddKeyChordListNormalizer
    : OddKeyChordListNormalizer
{
    public static AlternateHandOddKeyChordListNormalizer Instance { get; } = new();

    protected override ChordList NormalizeCore(ChordList list)
    {
        int oddKeys = list.Keys;
        int nextKeys = oddKeys + 1;
        int normalColumnsPerHand = oddKeys / 2;
        int middleColumnIndex = normalColumnsPerHand;
        var oldChords = list.Chords;
        int chordCount = oldChords.Length;
        var nextChords = new Chord[chordCount];
        int middleColumnOffset = 0;

        for (int chordIndex = 0; chordIndex < chordCount; chordIndex++)
        {
            var oldChord = oldChords[chordIndex];
            var oldNotes = oldChord.Notes;
            var nextNotes = oldNotes;

            int newMiddleColumn = middleColumnIndex + middleColumnOffset;
            var middleState = oldNotes.GetState(middleColumnIndex);
            nextNotes.Insert(newMiddleColumn, NoteState.Void);

            nextChords[chordIndex] = new()
            {
                Offset = oldChord.Offset,
                Notes = nextNotes,
            };

            // Only alternate the column after finishing a note
            if (middleState is NoteState.Release or NoteState.Rice)
            {
                middleColumnOffset.ToggleBinaryRef();
            }
        }

        return new(nextKeys, nextChords);
    }
}
