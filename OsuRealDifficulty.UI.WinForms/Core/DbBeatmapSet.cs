using Garyon.Extensions;
using OsuParsers.Database.Objects;
using OsuParsers.Enums;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class DbBeatmapSet
{
    private readonly List<DbBeatmap> _beatmaps = new();

    public IReadOnlyList<DbBeatmap> Beatmaps => _beatmaps;

    public void AddBeatmap(DbBeatmap beatmap)
    {
        _beatmaps.Add(beatmap);
    }

    public BeatmapSet DecodeSet(DirectoryInfo baseOsuDirectoryInfo)
    {
        var list = _beatmaps.Select(b => b.Read(baseOsuDirectoryInfo))
            .ToList();
        return new(list);
    }

    public bool ContainsWithRuleset(Ruleset ruleset)
    {
        return _beatmaps.Any(s => s.Ruleset == ruleset);
    }

    public bool ContainsManiaWithKeyCount(int keyCount)
    {
        return _beatmaps.Any(s => s.IsManiaWithKeyCount(keyCount));
    }

    public IEnumerable<DbBeatmap> OfRuleset(Ruleset ruleset)
    {
        return _beatmaps.Where(s => s.Ruleset == ruleset);
    }

    public IEnumerable<DbBeatmap> WithManiaRuleset()
    {
        return OfRuleset(Ruleset.Mania);
    }

    public IEnumerable<DbBeatmap> WithManiaKeyCount(int keyCount)
    {
        return _beatmaps.Where(s => s.IsManiaWithKeyCount(keyCount));
    }
}
