using System.Text.Json.Serialization;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class AppSettings
{
    public static AppSettings Instance { get; set; } = new();

    public bool AnalyzeAllOnStartup = false;
    public bool AnalyzeAllOnDatabaseRefresh = false;
    public bool AnalyzeOnSelection = true;
    public bool InvalidateAllCachedCalculationsOnRefresh = true;

    public string? BaseOsuDataDirectoryString
    {
        get => BaseOsuDataDirectory?.FullName;
        set
        {
            if (value is null)
            {
                BaseOsuDataDirectory = null;
            }
            else
            {
                BaseOsuDataDirectory = new(value);
            }
        }
    }
    public string? BaseSongsDirectoryString
    {
        get => BaseSongsDirectory?.FullName;
        set
        {
            if (value is null)
            {
                BaseSongsDirectory = null;
            }
            else
            {
                BaseSongsDirectory = new(value);
            }
        }
    }

    [JsonIgnore]
    public DirectoryInfo? BaseOsuDataDirectory;
    [JsonIgnore]
    public DirectoryInfo? BaseSongsDirectory;

    [JsonIgnore]
    public DirectoryInfo EffectiveBaseOsuDataDirectory
        => BaseOsuDataDirectory
        ?? GetDefaultOsuDataDirectory();

    [JsonIgnore]
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
