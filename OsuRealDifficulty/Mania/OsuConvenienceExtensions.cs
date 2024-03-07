using OsuFileTools;
using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;

namespace OsuRealDifficulty.Mania;

public static class OsuConvenienceExtensions
{
    public static int ManiaKeyCount(this Beatmap beatmap)
    {
        return ManiaKeyCount(beatmap.DifficultySection);
    }
    public static int ManiaKeyCount(this BeatmapDifficultySection difficultySection)
    {
        return (int)difficultySection.CircleSize;
    }

    public static BeatLength BeatLength(this TimingPoint timingPoint)
    {
        return new(timingPoint.BeatLength);
    }
}
