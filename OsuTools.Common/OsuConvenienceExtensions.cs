using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Database.Objects;
using OsuParsers.Decoders;
using OsuParsers.Enums;

namespace OsuTools.Common;

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
        return new(timingPoint.BeatLength / 1000);
    }

    // ok peppy but why the fuck did you do this?
    public static double GetSliderVelocity(this TimingPoint timingPoint)
    {
        double rate = timingPoint.BeatLength;
        return 100 / -rate;
    }

    public static void SetSliderVelocity(this TimingPoint timingPoint, double value)
    {
        var rate = 100 / -value;
        timingPoint.BeatLength = rate;
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

    public static bool HasNoBeatmapSetValue(this DbBeatmap beatmap)
    {
        return beatmap.BeatmapSetId <= 0;
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
    public static Beatmap? Read(this DbBeatmap beatmap, DirectoryInfo baseOsuDirectoryInfo)
    {
        var file = beatmap.FileInfo(baseOsuDirectoryInfo);
        if (!file.Exists)
            return null;
        return BeatmapDecoder.Decode(file);
    }

    public static string RomanizedOrUnicodeTitle(this DbBeatmap beatmap)
    {
        return beatmap.Title.DefaultIfWhiteSpace(beatmap.TitleUnicode);
    }

    public static string RomanizedOrUnicodeArtist(this DbBeatmap beatmap)
    {
        return beatmap.Artist.DefaultIfWhiteSpace(beatmap.ArtistUnicode);
    }

    public static string DefaultIfWhiteSpace(this string s, string @default)
    {
        if (string.IsNullOrWhiteSpace(s))
            return @default;

        return s;
    }

    #endregion
}
