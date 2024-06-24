namespace OsuRealDifficulty.Mania;

public readonly record struct ChordPressColumns(
    Chord Chord, BitVector32 PressColumns)
{
    public int Offset => Chord.Offset;

    public static ChordPressColumns EmptyForOffset(int offset)
    {
        var chord = Chord.WithOffset(offset);
        var pressColumns = new BitVector32();
        return new(chord, pressColumns);
    }

    public sealed class AscendingOffsetComparer
        : IComparer<ChordPressColumns>
    {
        public static AscendingOffsetComparer Instance { get; } = new();

        public int Compare(ChordPressColumns x, ChordPressColumns y)
        {
            return x.Offset.CompareTo(y.Offset);
        }
    }
}
