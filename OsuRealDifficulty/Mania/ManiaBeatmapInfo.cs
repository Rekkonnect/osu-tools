namespace OsuRealDifficulty.Mania;

public class ManiaBeatmapInfo
{
    public required Beatmap? Beatmap { get; init; }

    public ChordList ChordList => ChordListInfo.ChordList;
    public ChordList? NormalizedChordList => NormalizedChordListInfo?.ChordList;

    public ChordList NormalizedOrSourceChordList
        => NormalizedChordList ?? ChordList;

    public required ChordListInfo ChordListInfo { get; init; }
    public required ChordListInfo? NormalizedChordListInfo { get; init; }

    public required HandOccupationList? HandOccupations { get; init; }

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
