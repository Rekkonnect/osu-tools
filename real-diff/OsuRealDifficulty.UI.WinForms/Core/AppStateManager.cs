using OsuParsers.Database.Objects;
using OsuParsers.Enums;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class AppStateManager(AppState appState, AppSettings? customSettings)
{
    public static readonly AppStateManager Instance
        = new(AppState.Instance, null);

    public readonly AppState AppState = appState;
    public readonly AppSettings? CustomSettings = customSettings;

    public AppSettings EffectiveSettings
        => CustomSettings ?? AppSettings.Instance;

    public void LoadDbBeatmapSetDatabase()
    {
        var database = AppState.OsuDatabaseManager.ReadEntireDbBeatmapSetDatabase();
        AppState.BeatmapSetDatabase = database;

        var maniaDatabase = database.Filter(IsProperMania);
        AppState.ManiaBeatmapSetDatabase = maniaDatabase;

        if (EffectiveSettings.InvalidateAllCachedCalculationsOnRefresh)
        {
            AppState.CalculationCache.Clear();
        }
    }

    private static bool IsProperMania(DbBeatmap beatmap)
    {
        // .osz2 files are submitted beatmaps, which may also sometimes be deleted
        // they also tend to have all their diffs set to 0
        return beatmap.Ruleset is Ruleset.Mania
            && !beatmap.IsOsz2;
    }
}
