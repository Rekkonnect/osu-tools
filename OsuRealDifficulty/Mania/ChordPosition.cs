namespace OsuRealDifficulty.Mania;

// eventually we might need to use this
// this will replace all offset-related properties aiming for a
// much more efficient translation of offset -> index during analysis
// of committed annotations, and efficiently traversing the chord list
// that have been annotated with relevant annotations
// so far performance is up to par and this switch is not mandated

/// <summary>
/// Represents the position of a chord in the beatmap. This also includes
/// the index of the chord within the chord list. The type of the chord list
/// is also reflected via <see cref="ChordListType"/>.
/// </summary>
public struct ChordPosition
{
    const uint _listTypeMask = 0xFF00_0000;
    const uint _listIndexMask = ~_listTypeMask;

    private uint _offset;
    private uint _chordListValue;

    public int Offset
    {
        get
        {
            return (int)_offset;
        }
        set
        {
            _offset = (uint)value;
        }
    }

    public int ChordListIndex
    {
        get
        {
            return (int)(_chordListValue & _listIndexMask);
        }
        set
        {
            var maskedValue = (uint)value & _listIndexMask;
            var listType = _chordListValue & _listTypeMask;
            _chordListValue = listType | maskedValue;
        }
    }

    public ChordListType ChordListType
    {
        get
        {
            var maskedValue = _chordListValue & _listTypeMask;
            var shiftedValue = maskedValue >> 24;
            return (ChordListType)shiftedValue;
        }
        set
        {
            var shiftedValue = (uint)value << 24;
            var listIndex = _chordListValue & _listIndexMask;
            _chordListValue = listIndex | shiftedValue;
        }
    }
}
