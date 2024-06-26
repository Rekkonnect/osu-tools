﻿using Garyon.Extensions;
using OsuParsers.Database.Objects;
using OsuParsers.Enums;
using OsuTools.Common;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class DbBeatmapSetDatabase
{
    private readonly Dictionary<int, DbBeatmapSet> _beatmapSets = new();
    private readonly BeatmapSetIdDictionary _beatmapSetIdDictionary = new();

    public int BeatmapSetCount => _beatmapSets.Count;

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

    public DbBeatmapSetDatabase Filter(Predicate<DbBeatmap> beatmapFilter)
    {
        var database = new DbBeatmapSetDatabase();
        database._beatmapSetIdDictionary.CopyFrom(_beatmapSetIdDictionary);
        foreach (var entry in _beatmapSets)
        {
            var sourceSet = entry.Value;
            var newSet = new DbBeatmapSet(entry.Key);
            var filteredBeatmaps = sourceSet.Beatmaps.WherePredicate(beatmapFilter);
            newSet.AddRange(filteredBeatmaps);

            // Do not add empty beatmap sets
            if (newSet.Beatmaps.Count > 0)
            {
                database._beatmapSets[entry.Key] = newSet;
            }
        }
        return database;
    }

    private int GetOrInventBeatmapSetId(DbBeatmap beatmap)
    {
        if (beatmap.HasNoBeatmapSetValue())
        {
            return _beatmapSetIdDictionary.IdFor($"{beatmap.Title} - {beatmap.Artist} - {beatmap.FolderName}");
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
            set = new(id);
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

        public void CopyFrom(BeatmapSetIdDictionary other)
        {
            _ids.AddRange(other._ids);
        }

        public BeatmapSetIdDictionary Clone()
        {
            var result = new BeatmapSetIdDictionary();
            result.CopyFrom(this);
            return result;
        }

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
