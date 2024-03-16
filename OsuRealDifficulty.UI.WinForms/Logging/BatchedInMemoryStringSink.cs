using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Sinks.PeriodicBatching;

namespace OsuRealDifficulty.UI.WinForms.Logging;

public class BatchedInMemoryStringSink(
    MessageTemplateTextFormatter formatter,
    InMemoryStringSink sink)
    : IBatchedLogEventSink
{
    private readonly MessageTemplateTextFormatter _formatter = formatter;
    private readonly InMemoryStringSink _sink = sink;

    public Task EmitBatchAsync(IEnumerable<LogEvent> batch)
    {
        var writer = new StringWriter();
        var builder = writer.GetStringBuilder();
        foreach (var @event in batch)
        {
            _formatter.Format(@event, writer);
        }
        _sink.EmitStringBuilder(builder);
        return Task.CompletedTask;
    }

    public Task OnEmptyBatchAsync()
    {
        return Task.CompletedTask;
    }
}
