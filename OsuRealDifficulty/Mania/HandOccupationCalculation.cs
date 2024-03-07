using System.Collections.Specialized;

namespace OsuRealDifficulty.Mania;

public static class HandOccupationCalculation
{
    public static HandOccupationList GetHandOccupations(ChordList list)
    {
        if (list.IsOddKey)
        {
            throw new InvalidOperationException(
                $"The chord list must have an even key count. Consider using {nameof(OddKeyNormalization)}.");
        }

        int keysPerHand = list.Keys / 2;

        var occupations = new HandOccupationList();

        // Initialize the columns as fully burnt to trigger the initial press
        var leftBurns = new BitVector32(int.MaxValue);
        var rightBurns = new BitVector32(int.MaxValue);

        var chords = list.Chords;
        for (int i = 0; i < chords.Length; i++)
        {
            var chord = chords[i];
            var occupation = CalculateHandOccupation(chord);
            occupations.Add(occupation);
        }

        return occupations;

        HandOccupationEvent CalculateHandOccupation(Chord chord)
        {
            var localLeftBurns = new BitVector32();
            var localRightBurns = new BitVector32();

            var leftHand = HandState.Void;
            var rightHand = HandState.Void;

            for (int i = 0; i < keysPerHand; i++)
            {
                // Left

                int leftColumn = i;
                EvaluateHandColumn(
                    chord,
                    leftColumn,
                    ref localLeftBurns,
                    ref leftHand);

                // Right

                int rightColumn = i + keysPerHand;
                EvaluateHandColumn(
                    chord,
                    rightColumn,
                    ref localRightBurns,
                    ref rightHand);
            }

            ApplyBurns(ref leftBurns, ref localLeftBurns, ref leftHand);
            ApplyBurns(ref rightBurns, ref localRightBurns, ref rightHand);

            return new()
            {
                Offset = chord.Offset,
                Occupation = new(leftHand, rightHand),
            };

            void ApplyBurns(
                ref BitVector32 burns,
                ref BitVector32 localBurns,
                ref HandState hand)
            {
                int burnsOverlap = burns.Data & localBurns.Data;
                if (burnsOverlap is not 0)
                {
                    // We need a new press
                    burns = localBurns;
                    hand |= HandState.Press;
                }
                else
                {
                    burns = burns.Or(localBurns);
                }
            }
        }
    }

    private static void EvaluateHandColumn(
        Chord chord,
        int column,
        ref BitVector32 localColumnBurns,
        ref HandState handState)
    {
        var noteState = chord.Notes.GetState(column);
        bool requiresBurn = RequiresBurn(noteState);
        localColumnBurns.Set(column, requiresBurn);
        RegisterNoteIntoHandState(ref handState, noteState);
    }

    private static bool RequiresBurn(NoteState note)
    {
        return note
            is NoteState.Rice
            or NoteState.Press;
    }

    private static void RegisterNoteIntoHandState(ref HandState hand, NoteState leftNoteState)
    {
        switch (leftNoteState)
        {
            case NoteState.Rice:
                hand |= HandState.FingerHit;
                break;
            case NoteState.Press:
                hand |= HandState.FingerHit;
                break;
            case NoteState.Hold:
                hand |= HandState.Hold;
                break;
            case NoteState.Release:
                hand |= HandState.FingerRelease;
                break;
        }
    }
}
