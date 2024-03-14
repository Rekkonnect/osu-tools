using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.PeriodicBatching;

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

    public static LoggerConfiguration BatchedInMemoryString(
        this LoggerSinkConfiguration configuration,
        LogEventLevel eventLevel = LogEventLevel.Information,
        int maxStringLength = InMemoryStringSink.DefaultMaxStringLength,
        PeriodicBatchingSinkOptions? batchingOptions = null)
    {
        InMemoryStringSink.Instance.MaxStringLength = maxStringLength;
        var batchedSink = new BatchedInMemoryStringSink(
            InMemoryStringSink.Instance);

        batchingOptions ??= new PeriodicBatchingSinkOptions
        {
            Period = TimeSpan.FromSeconds(5),
            EagerlyEmitFirstEvent = true,
            QueueLimit = 10000,
        };

        var batchingSink = new PeriodicBatchingSink(batchedSink, batchingOptions);

        return configuration
            .Sink(batchingSink, eventLevel);
    }
}
