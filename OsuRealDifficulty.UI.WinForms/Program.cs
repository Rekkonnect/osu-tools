using OsuRealDifficulty.UI.WinForms.Core;
using OsuRealDifficulty.UI.WinForms.Logging;
using Serilog;

namespace OsuRealDifficulty.UI.WinForms;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    internal static void Main()
    {
        ApplicationConfiguration.Initialize();
        SetDefaultFont();

        SetupSerilog();
        SetupAppSettings();

        Application.Run(new MainForm());
    }

    private static void SetDefaultFont()
    {
        var mainFont = ThemeFonts.Instance.MainFont;
        if (mainFont is not null)
        {
            Application.SetDefaultFont(mainFont);
        }
    }

    private static void SetupSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(
                "logs/mania-diff-winforms.txt",
                rollingInterval: RollingInterval.Day,
                outputTemplate: LoggerExtensionsEx.DefaultOutputTemplate)
            .WriteTo.BatchedInMemoryString()
            .CreateLogger();

        Application.ApplicationExit += LogApplicationExit;
        Application.ApplicationExit += CloseAndFlushBeforeExiting;

        Log.Information("---- Application is starting -- Serilog was setup");
    }

    private static void LogApplicationExit(object? sender, EventArgs e)
    {
        Log.Information($"{nameof(Application.ApplicationExit)} invoked");
    }

    private static void CloseAndFlushBeforeExiting(object? sender, EventArgs e)
    {
        Log.CloseAndFlush();
    }

    private static void SetupAppSettings()
    {
        AppSettingsManager.Instance.OverwriteSettingsInstance();

        Application.ApplicationExit += WriteSettings;
    }

    private static void WriteSettings(object? sender, EventArgs e)
    {
        AppSettingsManager.Instance.Save(AppSettings.Instance);
    }
}
