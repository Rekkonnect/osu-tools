using OsuParsers.Beatmaps;

namespace OsuRealDifficulty.UI.WinForms.Core;

public sealed class BeatmapSet
{
    private readonly List<Beatmap> _beatmaps = new();

    public BeatmapSet() { }

    public BeatmapSet(List<Beatmap> beatmaps)
    {
        _beatmaps = beatmaps;
    }

    public void AddBeatmap(Beatmap beatmap)
    {
        _beatmaps.Add(beatmap);
    }
}
