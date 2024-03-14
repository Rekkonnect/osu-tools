using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace OsuRealDifficulty.UI.WinForms.Logging;

public static class LoggerExtensions
{
    public static LoggerConfiguration InMemoryString(
        this LoggerSinkConfiguration configuration,
        LogEventLevel eventLevel = LogEventLevel.Information,
        int maxStringLength = InMemoryStringSink.DefaultMaxStringLength)
    {
        InMemoryStringSink.Instance.MaxStringLength = maxStringLength;

        return configuration
            .Sink(InMemoryStringSink.Instance, eventLevel);
    }
}
