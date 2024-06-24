using Garyon.Extensions;
using Garyon.Functions;
using OsuParsers.Database.Objects;
using OsuParsers.Enums;
using OsuTools.Common;

namespace OsuRealDifficulty.UI.WinForms.Core;

public sealed class DbBeatmapSet(int id)
{
    private readonly List<DbBeatmap> _beatmaps = new();

    public IReadOnlyList<DbBeatmap> Beatmaps => _beatmaps;

    public int SetId { get; } = id;

    public string Title => Beatmaps[0].Title;
    public string TitleUnicode => Beatmaps[0].TitleUnicode;
    public string RomanizedOrUnicodeTitle => Beatmaps[0].RomanizedOrUnicodeTitle();
    public string Artist => Beatmaps[0].Artist;
    public string ArtistUnicode => Beatmaps[0].ArtistUnicode;
    public string RomanizedOrUnicodeArtist => Beatmaps[0].RomanizedOrUnicodeArtist();
    public string Source => Beatmaps[0].Source;
    public string Tags => Beatmaps[0].Tags;
    public string Creator => Beatmaps[0].Creator;

    public void AddBeatmap(DbBeatmap beatmap)
    {
        _beatmaps.Add(beatmap);
    }

    public void AddRange(IEnumerable<DbBeatmap> beatmaps)
    {
        foreach (var beatmap in beatmaps)
        {
            AddBeatmap(beatmap);
        }
    }

    public BeatmapSet DecodeSet(DirectoryInfo baseOsuDirectoryInfo)
    {
        var list = _beatmaps.Select(b => b.Read(baseOsuDirectoryInfo))
            .Where(Predicates.NotNull)
            .ToList();
        return new(list!);
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
