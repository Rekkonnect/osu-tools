namespace OsuRealDifficulty.Mania;

public static class OddKeyNormalization
{
    /// <summary>
    /// Normalizes the odd-key chord list into an even-key chord list, accounting
    /// for alternating the hands for the special middle column.
    /// </summary>
    /// <param name="oddKeyChordList">
    /// The odd key chord list. Providing an even key chord list will
    /// return <see langword="null"/>.
    /// </param>
    /// <returns>
    /// If the given chord list is for a field with an even key count,
    /// <see langword="null"/> is returned. Otherwise, a newly created chord
    /// list is returned.
    /// </returns>
    public static ChordList? NormalizeWithAlternateHands(ChordList oddKeyChordList)
    {
        return AlternateHandOddKeyChordListNormalizer.Instance
            .Normalize(oddKeyChordList);
    }
}

public abstract class OddKeyChordListNormalizer
{
    public ChordList? Normalize(ChordList list)
    {
        if (!list.IsOddKey)
        {
            return null;
        }

        return NormalizeCore(list);
    }

    protected abstract ChordList NormalizeCore(ChordList list);
}

public sealed class AlternateHandOddKeyChordListNormalizer : OddKeyChordListNormalizer
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
