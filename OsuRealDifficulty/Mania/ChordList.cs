namespace OsuRealDifficulty.Mania;

// TODO: Into record or struct?
// TODO: Chord[] into Memory<Chord>
public class ChordList(int keys, Chord[] chords)
{
    public readonly int Keys = keys;
    public readonly Chord[] Chords = chords;
    public readonly ReadOnlyMemory<Chord> ChordMemory = chords;

    public bool IsOddKey => Keys.IsOdd();
    public bool IsEvenKey => !IsOddKey;
}

public class ManiaBeatmapInfo
{
    public required Beatmap? Beatmap { get; init; }

    public ChordList ChordList => ChordListInfo.ChordList;
    public ChordList? NormalizedChordList => NormalizedChordListInfo?.ChordList;

    public ChordList NormalizedOrSourceChordList
        => NormalizedChordList ?? ChordList;

    public required ChordListInfo ChordListInfo { get; init; }
    public required ChordListInfo? NormalizedChordListInfo { get; init; }

    public required TimingPointInfo TimingPointInfo { get; init; }

    public required OrderedMapList<int, BeatSnappedPosition>
        ChordBeatSnappedPositions { get; init; }

    public required OrderedMapList<int, SnappedPosition>
        ChordSnappedPositions { get; init; }

    public int HitObjectCount
        => Beatmap?.HitObjects.Count
        ?? ChordListInfo.NonEmptyPressColumns
            .Sum(s => s.PressColumns.PopCount());
}

public class TimingPointInfo
{
    public required EncapsulatedTimingPointList EncapsulatedTimingPoints { get; init; }
    public required BeatLength AverageBeatLength { get; init; }
}

public class ChordListInfo
{
    public required ChordList ChordList { get; init; }
    public required ChordPressColumnsList PressColumns { get; init; }
    public required ChordPressColumnsList NonEmptyPressColumns { get; init; }
}

public class ChordPressColumnsList : List<ChordPressColumns>
{
    public ChordPressColumnsList() { }

    public ChordPressColumnsList(int capacity)
        : base(capacity) { }

    public void DeconstructLists(out Chord[] chords, out BitVector32[] pressColumns)
    {
        int count = Count;
        chords = new Chord[count];
        pressColumns = new BitVector32[count];

        for (int i = 0; i < count; i++)
        {
            var current = this[i];
            chords[i] = current.Chord;
            pressColumns[i] = current.PressColumns;
        }
    }
}

public readonly record struct ChordPressColumns(Chord Chord, BitVector32 PressColumns);
