using System.Collections.Specialized;
using System.Diagnostics;

namespace OsuRealDifficulty.Mania;

/// <summary>
/// Represents the state of the notes of a chord.
/// </summary>
/// <remarks>
/// This supports up to 10 keys, shown by <seealso cref="ChordNotesFacts.MaxColumns"/>.
/// For more than 10 keys, use <seealso cref="HighKeyChordNotes"/>.
/// </remarks>
[DebuggerDisplay($"{{{nameof(DebuggerDisplay)}(),nq}}")]
public struct ChordNotes : IEquatable<ChordNotes>
{
    private const uint columnMask = 0b111;
    private const int columnMaskLength = 3;

    private uint _bits;

    public ChordNotes(uint bits)
    {
        _bits = bits;
    }

    public void SetState(int column, NoteState state)
    {
        int shift = column * columnMaskLength;
        uint mask = columnMask << shift;
        uint stateValue = (uint)state << shift;
        _bits = ReplaceBits(_bits, mask, stateValue);
    }

    public readonly NoteState GetState(int column)
    {
        uint stateBits = GetColumnBits(column);
        return (NoteState)stateBits;
    }

    public void Insert(int column, NoteState state)
    {
        /*
         * Visualization
         * Assume bits:
         * GGG_FFF_EEE_DDD_CCC_BBB_AAA
         * We insert column with state HHH at index 1
         * We want the following:
         * Right mask:
         * 000_000_000_000_000_000_111
         * Transformation:
         * 000_GGG_FFF_EEE_DDD_CCC_BBB_AAA
         * 000_GGG_FFF_EEE_DDD_CCC_BBB_000
         * GGG_FFF_EEE_DDD_CCC_BBB_000_000
         * GGG_FFF_EEE_DDD_CCC_BBB_HHH_000
         * GGG_FFF_EEE_DDD_CCC_BBB_HHH_AAA
         */
        int shift = column * columnMaskLength;
        uint mask = (1U << shift) - 1U;
        var bits = _bits;
        var leftBits = bits & ~mask;
        var rightBits = bits & mask;
        var shiftedLeftBits = leftBits << columnMaskLength;
        var gappedBits = shiftedLeftBits | rightBits;
        var stateBits = (uint)state;
        var insertedBits = gappedBits | (stateBits << shift);
        _bits = insertedBits;
    }

    // TODO: Add a Remove column method

    public readonly bool IsActive(int column)
    {
        uint stateBits = GetColumnBits(column);
        return stateBits is not 0;
    }

    public readonly BitVector32 PressColumns(int keys)
    {
        BitVector32 result = default;

        for (int i = 0; i < keys; i++)
        {
            if (GetState(i) is NoteState.Rice or NoteState.Press)
            {
                result.Set(i, true);
            }
        }

        return result;
    }

    public readonly bool OnlyHasReleases(int keys)
    {
        for (int i = 0; i < keys; i++)
        {
            if (GetState(i) is NoteState.Release or NoteState.Void)
            {
                continue;
            }

            return false;
        }

        return true;
    }

    public readonly bool HasNoPresses(int keys)
    {
        for (int i = 0; i < keys; i++)
        {
            if (GetState(i) is NoteState.Release or NoteState.Void or NoteState.Hold)
            {
                continue;
            }

            return false;
        }

        return true;
    }

    private readonly uint GetColumnBits(int column)
    {
        int shift = column * columnMaskLength;
        uint stateBits = (_bits >> shift) & columnMask;
        return stateBits;
    }

    private static uint ReplaceBits(uint bits, uint mask, uint value)
    {
        return (bits & ~mask) | value;
    }

    public static bool operator ==(ChordNotes left, ChordNotes right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ChordNotes left, ChordNotes right)
    {
        return !(left == right);
    }

    public readonly bool Equals(ChordNotes other)
    {
        return _bits == other._bits;
    }

    public override readonly bool Equals(object obj)
    {
        return obj is ChordNotes && Equals((ChordNotes)obj);
    }

    public override readonly int GetHashCode()
    {
        return (int)_bits;
    }

    public static ChordNotes FromStates(params NoteState[] states)
    {
        var notes = new ChordNotes();

        for (int i = 0; i < states.Length; i++)
        {
            notes.SetState(i, states[i]);
        }

        return notes;
    }

    public readonly string DebuggerDisplay()
    {
        return ToString(ChordNotesFacts.MaxColumns);
    }

    public readonly string ToString(int columns)
    {
        int charCount = columns + 2;

        var chars = new char[charCount];
        chars[0] = '|';
        chars[charCount - 1] = '|';

        for (int i = 0; i < columns; i++)
        {
            var state = GetState(i);
            var displayChar = state switch
            {
                NoteState.Rice => '-',
                NoteState.Press => '-',
                NoteState.Hold => '|',
                NoteState.Release => '^',
                _ => ' ',
            };
            chars[i + 1] = displayChar;
        }

        return new(chars);
    }
}
