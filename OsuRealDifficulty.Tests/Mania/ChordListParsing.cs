using Garyon.Extensions;
using OsuRealDifficulty.Mania;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace OsuRealDifficulty.Tests.Mania;

/// <summary>
/// Helpers for parsing chord list strings for quickly defining patterns in tests.
/// Chord lists are formatted in the following way, like the examples below:
/// <br/>
/// <code>
/// |----|
/// |    |
/// | - -|
/// |-- -|
/// </code>
/// <br/>
/// LNs with offset (ms) + comments:
/// <code>
/// |----| 375
/// | ^  | 250
/// | |- | 125 with a comment
/// |-- -| 0
/// </code>
/// </summary>
public static class ChordListParsing
{
    public const char PlayfieldSeparator = '|';
    public const char VoidState = ' ';
    public const char RiceState = '-';
    public const char PressState = '-';
    public const char HoldState = '|';
    public const char ReleaseState = '^';

    public static ChordList Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            throw new FormatException("Cannot parse an empty string");

        var lines = s.GetLines();
        int lineCount = lines.Length;
        if (lineCount is 0)
            throw new FormatException("Cannot parse an empty string");

        int width = lines[0].Length;
        if (width < 3)
            throw new FormatException("Too few columns specified in the string");

        int rightFieldSeparatorIndex = lines[0].LastIndexOf(PlayfieldSeparator);
        int keyCount = rightFieldSeparatorIndex - 1;
        int minExpectedWidth = keyCount + 2;

        var chords = new Chord[lineCount];
        int lastOffset = -1;
        int chordArrayIndex = 0;
        bool? hasExplicitOffset = null;
        for (int lineIndex = lines.Length - 1; lineIndex >= 0; lineIndex--)
        {
            var line = lines[lineIndex];
            if (line.Length < minExpectedWidth)
            {
                throw new FormatException($"""
                    Line {lineIndex} does not contain at least {minExpectedWidth} characters (parsing {keyCount} keys).
                    """);
            }

            bool enclosedLeft = line[0] is PlayfieldSeparator;
            bool enclosedRight = line[minExpectedWidth - 1] is PlayfieldSeparator;
            if (!enclosedLeft)
            {
                throw new FormatException($"""
                    Line {lineIndex} doesn't properly enclose the left side of the playfield
                    """);
            }
            if (!enclosedRight)
            {
                throw new FormatException($"""
                    Line {lineIndex} doesn't properly enclose the right side of the playfield
                    """);
            }

            int chordOffset = lastOffset + 1;
            bool hasParsableOffset = false;
            // Parse the optional offset
            if (line.Length > minExpectedWidth)
            {
                int offsetStartIndex = minExpectedWidth;
                bool tryParse = false;
                while (true)
                {
                    if (offsetStartIndex >= line.Length)
                        break;

                    // Find non-whitespace characters to support ignored comments
                    // For example "|----| < chordjack" has the comment "< chordjack"
                    if (!line[offsetStartIndex].IsWhiteSpace())
                    {
                        tryParse = true;
                        break;
                    }

                    offsetStartIndex++;
                }

                if (tryParse)
                {
                    var span = line.AsSpan()[offsetStartIndex..];
                    bool parsed = span.TryParseFirstInt32(0, out var parsedOffset, out _);

                    if (parsed)
                    {
                        if (parsedOffset < chordOffset)
                        {
                            throw new FormatException($"""
                                Offsets must be in increasing order from bottom to top.
                                Line {lineIndex} with offset {parsedOffset} triggered this.
                                """);
                        }
                        hasParsableOffset = true;
                        chordOffset = parsedOffset;
                    }
                }
            }

            if (hasExplicitOffset is not null)
            {
                if (hasParsableOffset != hasExplicitOffset)
                {
                    throw new FormatException($"""
                        Offsets must either not be specified anywhere, or specified for all chords.
                        Line {lineIndex} with offset {chordOffset} triggered this.
                        """);
                }
            }
            hasExplicitOffset = hasParsableOffset;

            var notes = new ChordNotes();

            for (int charIndex = 1; charIndex <= keyCount; charIndex++)
            {
                int column = charIndex - 1;
                var c = line[charIndex];
                var state = NoteState.Void;
                switch (c)
                {
                    case VoidState:
                        continue;

                    case RiceState:
                        state = NoteState.Rice;
                        break;

                    case HoldState:
                        state = NoteState.Hold;
                        break;

                    case ReleaseState:
                        state = NoteState.Release;
                        break;

                    // Invalid note state character
                    default:
                        throw new FormatException(
                            $"Unexpected chord character {c} at line {lineIndex}");
                }

                CorrectLNState();

                notes.SetState(column, state);

                void CorrectLNState()
                {
                    if (chordArrayIndex <= 0)
                        return;

                    switch (state)
                    {
                        case NoteState.Rice:
                            return;

                        // We allow these cases
                        case NoteState.Hold:
                        case NoteState.Release:
                            break;
                    }

                    // Correct the previous chord's note from Rice to Press
                    ref var previousChord = ref chords[chordArrayIndex - 1];
                    ref var previousChordNotes = ref previousChord.Notes;
                    var previousState = previousChordNotes.GetState(column);
                    switch (previousState)
                    {
                        case NoteState.Void:
                        case NoteState.Release:
                            /*
                             * Invalid state examples:
                             * |  ^ |
                             * |  ^ |
                             * |    |
                             */
                            throw new FormatException("Invalid LN state continuation");

                        // We preserve hold states
                        case NoteState.Hold:
                            break;

                        // We replace rice with press
                        case NoteState.Rice:
                            previousChordNotes.SetState(column, NoteState.Press);
                            // safety assignment because struct
                            previousChord = previousChord with
                            {
                                Notes = previousChordNotes
                            };
                            break;

                        // We cannot have known this, unless the format has changed
                        case NoteState.Press:
                            throw new UnreachableException(
                                "We encountered a press state from the previous note");
                    }
                }
            }

            var chord = new Chord
            {
                Offset = chordOffset,
                Notes = notes,
            };

            chords[chordArrayIndex] = chord;

            lastOffset = chordOffset;
            chordArrayIndex++;
        }

        return new(keyCount, chords);
    }
}
