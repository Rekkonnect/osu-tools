using Serilog;
using System.Text.Json;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal class AppSettingsManager(string filePath)
{
    private const string defaultPath = "settings.json";

    public static AppSettingsManager Instance { get; } = new(defaultPath);

    private static readonly JsonSerializerOptions _serializationOptions = new()
    {
        IncludeFields = true,
        WriteIndented = true,
        IgnoreReadOnlyFields = true,
        IgnoreReadOnlyProperties = true,
        AllowTrailingCommas = true,
    };

    private readonly string _filePath = filePath;

    public FileInfo FilePath => new(_filePath);

    public void InitializeSettingsInstance()
    {
        var read = Read();
        if (read is not null)
        {
            AppSettings.Instance = read;
        }
    }

    public AppSettings? Read()
    {
        try
        {
            Log.Information(
                "Reading settings from {path}",
                _filePath);

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<AppSettings>(json, _serializationOptions);
        }
        catch (Exception ex)
        {
            Log.Error(
                ex,
                "Failed to parse app settings from path {path}",
                _filePath);
            return null;
        }
    }

    public void Save(AppSettings settings)
    {
        try
        {
            var serialized = JsonSerializer.Serialize(settings, _serializationOptions)!;
            File.WriteAllText(_filePath, serialized);

            Log.Information(
                "Successfully saved settings to {path}",
                _filePath);
        }
        catch (Exception ex)
        {
            Log.Error(
                ex,
                "Failed to write app settings to path {path}",
                _filePath);
        }
    }
}
