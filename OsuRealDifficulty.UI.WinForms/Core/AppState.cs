using OsuParsers.Beatmaps;
using OsuParsers.Database.Objects;
using OsuTools.Common;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class AppState
{
    public static readonly AppState Instance = new();

    public OsuDatabaseManager OsuDatabaseManager { get; set; }
        = OsuDatabaseManager.Instance;

    public DbBeatmapSetDatabase? BeatmapSetDatabase { get; set; }
    public DbBeatmapSetDatabase? ManiaBeatmapSetDatabase { get; set; }
    public DifficultyCalculationProfiles CalculationProfiles { get; set; }
        = DifficultyCalculationProfiles.Default;

    public BeatmapDifficultyCalculationCache CalculationCache { get; }
        = new();

    public BeatmapLoadProvider LoadProvider { get; } = new();
}

internal sealed class BeatmapLoadProvider
{
    // TODO TESTING MEMORY USAGE
    private bool _enableCaching = true;

    public BeatmapLoadCache Cache { get; } = new();

    public bool EnableCaching
    {
        get => _enableCaching;
        set
        {
            _enableCaching = value;
            if (!value)
            {
                Cache.Clear();
            }
        }
    }

    public Beatmap? Read(DbBeatmap dbBeatmap, DirectoryInfo baseDirectory)
    {
        var cached = Cache.GetRead(dbBeatmap);
        if (cached is not null)
        {
            return cached;
        }

        var result = dbBeatmap.Read(baseDirectory);
        if (_enableCaching && result is not null)
        {
            Cache.AddRead(dbBeatmap, result);
        }
        return result;
    }
}

internal sealed class BeatmapLoadCache
{
    public static readonly BeatmapLoadCache Instance = new();

    private readonly Dictionary<BeatmapIdKey, Beatmap> _beatmaps = new();

    public void AddRead(DbBeatmap dbBeatmap, Beatmap parsed)
    {
        var key = BeatmapIdKey.FromBeatmap(dbBeatmap);
        Add(key, parsed);
    }

    public void Add(BeatmapIdKey key, Beatmap beatmap)
    {
        _beatmaps.Add(key, beatmap);
    }

    public Beatmap? GetRead(DbBeatmap beatmap)
    {
        var key = BeatmapIdKey.FromBeatmap(beatmap);
        return Get(key);
    }

    public Beatmap? Get(BeatmapIdKey key)
    {
        return _beatmaps.GetValueOrDefault(key);
    }

    public void Clear()
    {
        _beatmaps.Clear();
    }
}

public readonly record struct BeatmapIdKey(string Folder, string Name)
{
    public static BeatmapIdKey FromBeatmap(DbBeatmap beatmap)
    {
        return new(beatmap.FolderName, beatmap.FileName);
    }
}
