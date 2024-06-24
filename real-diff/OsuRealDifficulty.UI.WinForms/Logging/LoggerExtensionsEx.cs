using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Sinks.PeriodicBatching;

namespace OsuRealDifficulty.UI.WinForms.Logging;

public static class LoggerExtensionsEx
{
    public const string DefaultOutputTemplate = "{Timestamp:[yyyy-MM-dd] [HH:mm:ss.fff zzz]} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

    public static LoggerConfiguration InMemoryString(
        this LoggerSinkConfiguration configuration,
        LogEventLevel eventLevel = LogEventLevel.Information,
        int maxStringLength = InMemoryStringSink.DefaultMaxStringLength)
    {
        InMemoryStringSink.Instance.MaxStringLength = maxStringLength;

        return configuration
            .Sink(InMemoryStringSink.Instance, eventLevel);
    }

    public static LoggerConfiguration BatchedInMemoryString(
        this LoggerSinkConfiguration configuration,
        LogEventLevel eventLevel = LogEventLevel.Information,
        int maxStringLength = InMemoryStringSink.DefaultMaxStringLength,
        string outputTemplate = DefaultOutputTemplate,
        PeriodicBatchingSinkOptions? batchingOptions = null)
    {
        InMemoryStringSink.Instance.MaxStringLength = maxStringLength;
        var formatter = new MessageTemplateTextFormatter(outputTemplate);
        var batchedSink = new BatchedInMemoryStringSink(
            formatter,
            InMemoryStringSink.Instance);

        batchingOptions ??= new PeriodicBatchingSinkOptions
        {
            Period = TimeSpan.FromMilliseconds(500),
            EagerlyEmitFirstEvent = true,
            QueueLimit = 10000,
        };

        var batchingSink = new PeriodicBatchingSink(batchedSink, batchingOptions);

        return configuration
            .Sink(batchingSink, eventLevel);
    }
}
