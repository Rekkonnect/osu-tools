using OsuParsers.Database;
using OsuParsers.Decoders;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class OsuDatabaseManager(AppSettings appSettings)
{
    public static OsuDatabaseManager Instance => new(AppSettings.Instance);

    public AppSettings AppSettings { get; } = appSettings;

    // Imagine designing all that parsing and stuff but completely failing to making it
    // half as easy to actually use the parsers after reading the files

    public OsuDatabase GetOsuDatabase()
    {
        var dbFile = OsuFilePath("osu!.db");
        return DatabaseDecoder.DecodeOsu(dbFile);
    }

    public CollectionDatabase GetCollectionDatabase()
    {
        var dbFile = OsuFilePath("collection.db");
        return DatabaseDecoder.DecodeCollection(dbFile);
    }

    public ScoresDatabase GetScoresDatabase()
    {
        var dbFile = OsuFilePath("scores.db");
        return DatabaseDecoder.DecodeScores(dbFile);
    }

    public PresenceDatabase GetPresenceDatabase()
    {
        var dbFile = OsuFilePath("presence.db");
        return DatabaseDecoder.DecodePresence(dbFile);
    }

    public DbBeatmapSetDatabase ReadEntireDbBeatmapSetDatabase()
    {
        var osuDatabase = GetOsuDatabase();
        var beatmapSetDatabase = new DbBeatmapSetDatabase();
        beatmapSetDatabase.AddRange(osuDatabase.Beatmaps);
        return beatmapSetDatabase;
    }

    private string OsuFilePath(string fileName)
    {
        return AppSettings.EffectiveBaseOsuDataDirectory
            .File(fileName)
            .FullName;
    }
}
