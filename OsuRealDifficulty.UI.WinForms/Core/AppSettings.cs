namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class AppSettings
{
    public static AppSettings Instance { get; } = new();

    public DirectoryInfo? BaseOsuDataDirectory { get; set; }
    public DirectoryInfo? BaseSongsDirectory { get; set; }

    public DirectoryInfo EffectiveBaseOsuDataDirectory
        => BaseOsuDataDirectory
        ?? GetDefaultOsuDataDirectory();

    public DirectoryInfo EffectiveBaseSongsDirectory
        => BaseSongsDirectory
        ?? GetDefaultEffectiveSongsDirectory();

    private DirectoryInfo GetDefaultEffectiveSongsDirectory()
    {
        return GetDefaultEffectiveOsuDirectory("Songs");
    }
    private DirectoryInfo GetDefaultEffectiveSkinsDirectory()
    {
        return GetDefaultEffectiveOsuDirectory("Skins");
    }
    private DirectoryInfo GetDefaultEffectiveExportsDirectory()
    {
        return GetDefaultEffectiveOsuDirectory("Exports");
    }
    private DirectoryInfo GetDefaultEffectiveReplaysDirectory()
    {
        return GetDefaultEffectiveOsuDirectory("Replays");
    }
    private DirectoryInfo GetDefaultEffectiveLogsDirectory()
    {
        return GetDefaultEffectiveOsuDirectory("Logs");
    }
    private DirectoryInfo GetDefaultEffectiveDownloadsDirectory()
    {
        return GetDefaultEffectiveOsuDirectory("Downloads");
    }
    private DirectoryInfo GetDefaultEffectiveScreenshotsDirectory()
    {
        return GetDefaultEffectiveOsuDirectory("Screenshots");
    }

    public DirectoryInfo GetDefaultEffectiveOsuDirectory(string directoryName)
    {
        return EffectiveBaseOsuDataDirectory
            .Subdirectory(directoryName)
            ;
    }

    private static DirectoryInfo GetDefaultOsuDataDirectory()
    {
        var localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var localappdataDirectory = new DirectoryInfo(localappdata);
        return localappdataDirectory
            .Subdirectory("osu!")
            ;
    }
}
