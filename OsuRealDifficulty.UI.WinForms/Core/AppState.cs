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
}
