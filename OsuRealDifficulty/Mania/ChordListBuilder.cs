using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects.Mania;
using OsuParsers.Enums;

namespace OsuRealDifficulty.Mania;

public static class ChordListBuilding
{
    public static ResultWithDiagnostics<ChordList> BuildChordList(Beatmap beatmap)
    {
        if (beatmap.GeneralSection.Mode is not Ruleset.Mania)
        {
            throw new ArgumentException("The beatmap is not a mania beatmap", nameof(beatmap));
        }

        int keys = beatmap.ManiaKeyCount();
        var builder = new ChordListBuilder(keys);

        var notes = beatmap.HitObjects.Cast<BaseManiaNote>();
        foreach (var note in notes)
        {
            builder.Add(note);
        }

        return builder.FinalizeList();
    }
}

public class ChordListBuilder(int keys)
{
    private readonly SortedDictionary<int, Chord> _chordsByOffsets = [];

    public readonly int Keys = keys;

    public void Set(int offset, int column, NoteState state)
    {
        var chord = _chordsByOffsets.GetValueOrDefault(offset);
        chord.Offset = offset;
        var notes = chord.Notes;
        notes.SetState(column, state);
        chord.Notes = notes;
        _chordsByOffsets[offset] = chord;
    }

    public void Add(BaseManiaNote note)
    {
        if (note is ManiaHoldNote hold)
        {
            Add(hold);
            return;
        }

        Set(note.StartTime, note.GetColumn(Keys), NoteState.Rice);
    }

    public void Add(ManiaHoldNote note)
    {
        int column = note.GetColumn(Keys);
        Set(note.StartTime, column, NoteState.Press);
        Set(note.EndTime, column, NoteState.Release);
    }

    public ResultWithDiagnostics<ChordList> FinalizeList()
    {
        Chord previousChord = default;
        var diagnosticBag = new DiagnosticBag();

        var chords = _chordsByOffsets.Values.ToArray();
        for (int i = 0; i < chords.Length; i++)
        {
            ref var chord = ref chords[i];
            ref var notes = ref chord.Notes;
            for (int column = 0; column < Keys; column++)
            {
                var state = notes.GetState(column);
                var previousState = previousChord.Notes.GetState(column);
                bool wasActiveHold = previousState
                    is NoteState.Hold or NoteState.Press;

                if (wasActiveHold)
                {
                    // We have an invalid overlapping note. It's better to ignore
                    // it, but issue an overlapping note diagnostic.
                    if (state is NoteState.Press or NoteState.Rice)
                    {
                        var identifier = new NoteIdentifier(chord.Offset, column);
                        var diagnostic = new OverlappingNoteDiagnostic(identifier, state);
                        diagnosticBag.Add(diagnostic);

                        notes.SetState(column, NoteState.Hold);
                    }
                }

                if (!wasActiveHold)
                {
                    // We have probably experienced an invalid overlapping note.
                    // Also issue a diagnostic. Preserve the note state.
                    if (state is NoteState.Release or NoteState.Hold)
                    {
                        var identifier = new NoteIdentifier(chord.Offset, column);
                        var diagnostic = new OverlappingNoteDiagnostic(identifier, state);
                        diagnosticBag.Add(diagnostic);
                    }
                }

                // We have a note that is being held, and no note event is registered
                // The column remains occupied, so we set the state to hold.
                if (state is NoteState.Void && wasActiveHold)
                {
                    notes.SetState(column, NoteState.Hold);
                }
            }

            previousChord = chord;
        }

        var chordList = new ChordList(Keys, chords);
        return new(chordList, diagnosticBag);
    }
}

public record ResultWithDiagnostics<T>(T Result, DiagnosticBag Diagnostics);
