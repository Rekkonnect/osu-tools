using Garyon.DataStructures;
using OsuFileTools;
using OsuParsers.Beatmaps;
using OsuTools.Common;
using System.Diagnostics.CodeAnalysis;

namespace OsuRealDifficulty.Mania;

public sealed class ManiaBeatmapInfoConstruction
{
    public static ManiaBeatmapInfoConstruction Instance { get; } = new();

    public ManiaBeatmapInfo CreateInfoForChordList(ChordList chordList)
    {
        var chordListInfo = GetChordListInfo(chordList);

        return new()
        {
            Beatmap = null!,
            ChordListInfo = chordListInfo,
            NormalizedChordListInfo = null!,
            TimingPointInfo = null!,
            ChordBeatSnappedPositions = null!,
            ChordSnappedPositions = null!,
        };
    }

    public ManiaBeatmapInfo CreateInfoForChordListWithNormalization(
        ChordList chordList,
        ChordList? normalizedChordList)
    {
        var chordListInfo = GetChordListInfo(chordList);
        var normalizedChordListInfo = GetChordListInfo(normalizedChordList);

        return new()
        {
            Beatmap = null!,
            ChordListInfo = chordListInfo,
            NormalizedChordListInfo = normalizedChordListInfo,
            TimingPointInfo = null!,
            ChordBeatSnappedPositions = null!,
            ChordSnappedPositions = null!,
        };
    }

    public ManiaBeatmapInfo CreateInfoForBeatmap(Beatmap beatmap)
    {
        var chordList = ChordListBuilding.BuildChordList(beatmap).Result;
        var normalizedChordList = OddKeyNormalization.NormalizeWithAlternateHands(chordList);

        var chordListInfo = GetChordListInfo(chordList);
        var normalizedChordListInfo = GetChordListInfo(normalizedChordList);

        var timingPointInfo = GetTimingPointInfo(beatmap);
        var chordBeatSnappedPositions = GetChordBeatSnappedPositions(beatmap);
        var chordSnappedPositions = GetChordSnappedPositions(beatmap);

        return new()
        {
            Beatmap = beatmap,
            ChordListInfo = chordListInfo,
            NormalizedChordListInfo = normalizedChordListInfo,
            TimingPointInfo = timingPointInfo,
            ChordBeatSnappedPositions = chordBeatSnappedPositions,
            ChordSnappedPositions = chordSnappedPositions,
        };
    }

    private OrderedMapList<int, SnappedPosition> GetChordSnappedPositions(Beatmap beatmap)
    {
        // TODO
        return null!;
    }

    private OrderedMapList<int, BeatSnappedPosition> GetChordBeatSnappedPositions(Beatmap beatmap)
    {
        // TODO
        return null!;
    }

    private TimingPointInfo GetTimingPointInfo(Beatmap beatmap)
    {
        var encapsulatedTimingPoints = EncapsulatedTimingPointList.FromBeatmap(beatmap);
        var averageBeatLength = CalculateAverageBeatLength(beatmap, encapsulatedTimingPoints);

        return new()
        {
            EncapsulatedTimingPoints = encapsulatedTimingPoints,
            AverageBeatLength = averageBeatLength,
        };
    }

    private BeatLength CalculateAverageBeatLength(
        Beatmap beatmap,
        EncapsulatedTimingPointList timingPoints)
    {
        int firstStartOffset = beatmap.HitObjects.Min(s => s.StartTime);
        int lastEndOffset = beatmap.HitObjects.Max(s => s.EndTime);

        var offsetCounters = new FlexibleInitializableValueDictionary<double, int>();

        foreach (var timingPoint in timingPoints.Encapsulations)
        {
            var beatLength = timingPoint.Parent.BeatLength;
            int startOffset = Math.Max(firstStartOffset, timingPoint.StartOffset);
            int endOffset = Math.Max(lastEndOffset, timingPoint.EndOffset);
            int length = endOffset - startOffset;
            if (length <= 0)
                continue;

            offsetCounters[beatLength] += length;
        }

        var maxOffsetCounter = offsetCounters.MaxBy(s => s.Value);
        var mostUtilizedBeatLength = maxOffsetCounter.Value;
        return new(mostUtilizedBeatLength);
    }

    [return: NotNullIfNotNull(nameof(chordList))]
    private ChordListInfo? GetChordListInfo(ChordList? chordList)
    {
        if (chordList is null)
            return null;

        var pressColumns = GetChordPressColumns(chordList);
        var nonEmptyPressColumns = GetNonEmptyChordPressColumns(pressColumns);

        return new()
        {
            ChordList = chordList,
            PressColumns = pressColumns,
            NonEmptyPressColumns = nonEmptyPressColumns,
        };
    }

    private static ChordPressColumnsList GetChordPressColumns(ChordList chordList)
    {
        var chords = chordList.Chords;
        int keys = chordList.Keys;
        var listResult = new ChordPressColumnsList(chords.Length);

        for (int i = 0; i < chords.Length; i++)
        {
            var chord = chords[i];
            var pressColumns = chord.Notes.PressColumns(keys);
            var combined = new ChordPressColumns(chord, pressColumns);
            listResult.Add(combined);
        }

        return listResult;
    }

    private static ChordPressColumnsList GetNonEmptyChordPressColumns(
        ChordPressColumnsList chordPressColumns)
    {
        var listResult = new ChordPressColumnsList(chordPressColumns.Count);

        for (int i = 0; i < chordPressColumns.Count; i++)
        {
            var pressColumns = chordPressColumns[i];
            if (pressColumns.PressColumns.Data is 0)
                continue;

            listResult.Add(pressColumns);
        }

        return listResult;
    }
}
