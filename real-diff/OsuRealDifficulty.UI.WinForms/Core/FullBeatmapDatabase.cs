namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class FullBeatmapDatabase
{
    private readonly Dictionary<int, BeatmapSet> _beatmapSets = new();

    public IEnumerable<BeatmapSet> BeatmapSets => _beatmapSets.Values;

    public FullBeatmapDatabase() { }

    internal FullBeatmapDatabase(Dictionary<int, BeatmapSet> sets)
    {
        _beatmapSets = sets;
    }
}
