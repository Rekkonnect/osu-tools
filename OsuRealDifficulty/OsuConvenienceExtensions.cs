using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Database.Objects;
using OsuParsers.Decoders;
using OsuParsers.Enums;

namespace OsuRealDifficulty;

public static class OsuConvenienceExtensions
{
    public static int ManiaKeyCount(this Beatmap beatmap)
    {
        return beatmap.DifficultySection.ManiaKeyCount();
    }
    public static int ManiaKeyCount(this BeatmapDifficultySection difficultySection)
    {
        return (int)difficultySection.CircleSize;
    }

    public static BeatLength BeatLength(this TimingPoint timingPoint)
    {
        return new(timingPoint.BeatLength);
    }

    #region DbBeatmap

    public static int ManiaKeyCount(this DbBeatmap beatmap)
    {
        return (int)beatmap.CircleSize;
    }

    public static int TotalObjectCount(this DbBeatmap beatmap)
    {
        return beatmap.CirclesCount
            + beatmap.SlidersCount
            + beatmap.SpinnersCount;
    }

    public static bool IsManiaWithKeyCount(this DbBeatmap beatmap, int maniaKeyCount)
    {
        return beatmap.Ruleset is Ruleset.Mania
            && beatmap.ManiaKeyCount() == maniaKeyCount;
    }

    public static string FullPath(this DbBeatmap beatmap, DirectoryInfo baseOsuDirectoryInfo)
    {
        return Path.Combine(
            baseOsuDirectoryInfo.FullName,
            beatmap.FolderName,
            beatmap.FileName);
    }
    public static FileInfo FileInfo(this DbBeatmap beatmap, DirectoryInfo baseOsuDirectoryInfo)
    {
        return new(beatmap.FullPath(baseOsuDirectoryInfo));
    }
    public static Beatmap Read(this DbBeatmap beatmap, DirectoryInfo baseOsuDirectoryInfo)
    {
        var file = beatmap.FileInfo(baseOsuDirectoryInfo);
        return BeatmapDecoder.Decode(file.FullName);
    }

    #endregion
}
