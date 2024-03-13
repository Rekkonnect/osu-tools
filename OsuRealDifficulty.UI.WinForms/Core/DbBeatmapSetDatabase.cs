using Garyon.Extensions;
using OsuParsers.Database.Objects;
using OsuParsers.Enums;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class DbBeatmapSetDatabase
{
    private readonly Dictionary<int, DbBeatmapSet> _beatmapSets = new();

    public IEnumerable<DbBeatmapSet> BeatmapSets => _beatmapSets.Values;
    public IEnumerable<DbBeatmap> AllBeatmaps => BeatmapSets.SelectMany(s => s.Beatmaps);

    public void AddRange(IEnumerable<DbBeatmap> beatmaps)
    {
        foreach (var beatmap in beatmaps)
        {
            Add(beatmap);
        }
    }

    public void Add(DbBeatmap beatmap)
    {
        var set = GetBeatmapSetFor(beatmap);
        set.AddBeatmap(beatmap);
    }

    private DbBeatmapSet GetBeatmapSetFor(DbBeatmap beatmap)
    {
        int id = beatmap.BeatmapSetId;
        return GetBeatmapSetForId(id);
    }

    private DbBeatmapSet GetBeatmapSetForId(int id)
    {
        bool found = _beatmapSets.TryGetValue(id, out var set);
        if (!found)
        {
            set = new();
            _beatmapSets[id] = set;
        }
        return set!;
    }

    public FullBeatmapDatabase DecodeSet(DirectoryInfo baseOsuDirectoryInfo)
    {
        var setValues = _beatmapSets
            .SelectValues(b => b.DecodeSet(baseOsuDirectoryInfo));

        // To resolve extension resolution ambiguity
        var dictionary = Enumerable.ToDictionary(setValues);
        return new(dictionary);
    }

    public IEnumerable<DbBeatmapSet> SetsWithRuleset(Ruleset ruleset)
    {
        return BeatmapSets
            .Where(s => s.ContainsWithRuleset(ruleset));
    }

    public IEnumerable<DbBeatmapSet> SetsWithManiaKeyCount(int maniaKeyCount)
    {
        return BeatmapSets
            .Where(s => s.ContainsManiaWithKeyCount(maniaKeyCount));
    }
}
