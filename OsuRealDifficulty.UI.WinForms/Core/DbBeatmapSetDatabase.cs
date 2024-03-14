using Garyon.Extensions;
using OsuParsers.Database.Objects;
using OsuParsers.Enums;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class DbBeatmapSetDatabase
{
    private readonly Dictionary<int, DbBeatmapSet> _beatmapSets = new();
    private readonly BeatmapSetIdDictionary _beatmapSetIdDictionary = new();

    public int Count => _beatmapSets.Count;

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

    private int GetOrInventBeatmapSetId(DbBeatmap beatmap)
    {
        if (beatmap.HasNoBeatmapSetValue())
        {
            return _beatmapSetIdDictionary.IdFor($"{beatmap.Title} - {beatmap.Artist}");
        }

        return beatmap.BeatmapSetId;
    }

    private DbBeatmapSet GetBeatmapSetFor(DbBeatmap beatmap)
    {
        int id = GetOrInventBeatmapSetId(beatmap);
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

    private sealed class BeatmapSetIdDictionary
    {
        private readonly Dictionary<string, int> _ids = new();

        public int IdFor(string name)
        {
            bool found = _ids.TryGetValue(name, out var id);
            if (found)
            {
                return id;
            }

            return Create(name);
        }

        private int Create(string name)
        {
            int nextId = -1000 - _ids.Count;
            _ids[name] = nextId;
            return nextId;
        }
    }
}
