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

        var maniaDatabase = database.Filter(s => s.Ruleset is Ruleset.Mania);
        AppState.ManiaBeatmapSetDatabase = maniaDatabase;

        if (EffectiveSettings.InvalidateAllCachedCalculationsOnRefresh)
        {
            AppState.CalculationCache.Clear();
        }
    }
}
