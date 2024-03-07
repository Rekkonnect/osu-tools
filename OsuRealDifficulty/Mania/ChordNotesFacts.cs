namespace OsuRealDifficulty.Mania;

public static class ChordNotesFacts
{
    public const int MaxColumns = 10;

    public static class FieldPresses
    {
        private static readonly ChordNotes[] _fieldNotes;

        static FieldPresses()
        {
            // Initialize field presses
            _fieldNotes = new ChordNotes[MaxColumns];
            for (int i = 0; i < MaxColumns; i++)
            {
                int columns = i + 1;
                var notes = new ChordNotes();

                for (int column = 0; column < columns; column++)
                {
                    notes.SetState(column, NoteState.Rice);
                }
            }
        }

        public static bool IsFieldPress(ChordNotes notes, int columns)
        {
            if (columns is < 1 or > MaxColumns)
                return false;

            return _fieldNotes[columns - 1] == notes;
        }
    }
}
