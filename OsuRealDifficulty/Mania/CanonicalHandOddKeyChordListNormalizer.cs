using Garyon.Extensions;
using Garyon.Objects;

namespace OsuRealDifficulty.Mania;

public sealed class CanonicalHandOddKeyChordListNormalizer
    : OddKeyChordListNormalizer
{
    public static CanonicalHandOddKeyChordListNormalizer Instance { get; } = new();

    protected override ChordList NormalizeCore(ChordList list)
    {
        int oddKeys = list.Keys;
        int nextKeys = oddKeys + 1;
        int normalColumnsPerHand = oddKeys / 2;
        int middleColumnIndex = normalColumnsPerHand;
        var oldChords = list.Chords;
        int chordCount = oldChords.Length;
        var nextChords = new Chord[chordCount];
        var previousUsedPress = HandPosition.Left;

        for (int chordIndex = 0; chordIndex < chordCount; chordIndex++)
        {
            var oldChord = oldChords[chordIndex];
            var oldNotes = oldChord.Notes;
            var nextNotes = oldNotes;

            var nextPressHand = GetPreferredHandForSpecialColumn(
                oldChord,
                oddKeys,
                previousUsedPress);
            previousUsedPress = nextPressHand;
            int nextMiddleColumnOffset = (int)nextPressHand.Opposite();

            int newMiddleColumn = middleColumnIndex + nextMiddleColumnOffset;
            nextNotes.Insert(newMiddleColumn, NoteState.Void);

            nextChords[chordIndex] = new()
            {
                Offset = oldChord.Offset,
                Notes = nextNotes,
            };
        }

        return new(nextKeys, nextChords);
    }

    private static HandPosition GetPreferredHandForSpecialColumn(
        Chord chord,
        int keys,
        HandPosition previousUsedPress)
    {
        var notes = chord.Notes;
        int specialKeyIndex = keys / 2;
        var specialState = notes.GetState(specialKeyIndex);
        switch (specialState)
        {
            case NoteState.Void:
            case NoteState.Hold:
            case NoteState.Release:
                return previousUsedPress;
        }

        var stats = GetHandActiveColumnStats(notes, keys, specialKeyIndex);
        var holdsComparison = stats.Left.Holds.GetComparisonResult(stats.Right.Holds);
        switch (holdsComparison)
        {
            // left < right
            case ComparisonResult.Less:
                return HandPosition.Left;

            // left > right
            case ComparisonResult.Greater:
                return HandPosition.Right;
        }

        var pressComparison = stats.Left.Presses.GetComparisonResult(stats.Right.Presses);
        switch (pressComparison)
        {
            // left < right
            case ComparisonResult.Less:
                return HandPosition.Right;

            // left > right
            case ComparisonResult.Greater:
                return HandPosition.Left;
        }

        return previousUsedPress.Opposite();
    }

    private static HandActiveColumnStats GetHandActiveColumnStats(
        ChordNotes notes,
        int keys,
        int specialKey)
    {
        var left = GetActiveColumnStats(notes, 0, specialKey - 1);
        var right = GetActiveColumnStats(notes, specialKey + 1, keys - 1);
        return new(left, right);
    }

    private static ActiveColumnStats GetActiveColumnStats(
        ChordNotes notes,
        int start,
        int end)
    {
        var stats = new ActiveColumnStats();

        for (int i = start; i <= end; i++)
        {
            var state = notes.GetState(i);
            switch (state)
            {
                case NoteState.Rice:
                case NoteState.Press:
                    stats.Presses++;
                    break;

                case NoteState.Hold:
                    stats.Holds++;
                    break;
            }
        }

        return stats;
    }
}

public struct HandActiveColumnStats(ActiveColumnStats left, ActiveColumnStats right)
{
    public ActiveColumnStats Left = left;
    public ActiveColumnStats Right = right;
}

public struct ActiveColumnStats
{
    public byte Presses;
    public byte Holds;
}
