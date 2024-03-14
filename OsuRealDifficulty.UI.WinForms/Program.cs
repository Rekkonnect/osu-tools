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
                rollingInterval: RollingInterval.Hour)
            .WriteTo.BatchedInMemoryString()
            .CreateLogger();

        Application.ApplicationExit += LogApplicationExit;
        Application.ApplicationExit += CloseAndFlushBeforeExiting;

        Log.Information("Serilog was setup -- Application is starting");
    }

    private static void LogApplicationExit(object? sender, EventArgs e)
    {
        Log.Information($"{nameof(Application.ApplicationExit)} invoked");
    }

    private static void CloseAndFlushBeforeExiting(object? sender, EventArgs e)
    {
        Log.CloseAndFlush();
    }
}
