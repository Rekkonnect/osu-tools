using Serilog.Events;
using Serilog.Sinks.PeriodicBatching;
using System.Text;

namespace OsuRealDifficulty.UI.WinForms.Logging;

public class BatchedInMemoryStringSink(InMemoryStringSink sink)
    : IBatchedLogEventSink
{
    private readonly InMemoryStringSink _sink = sink;

    public Task EmitBatchAsync(IEnumerable<LogEvent> batch)
    {
        var builder = new StringBuilder();
        foreach (var @event in batch)
        {
            builder.AppendLine(@event.RenderMessage());
        }
        _sink.EmitStringBuilder(builder);
        return Task.CompletedTask;
    }

    public Task OnEmptyBatchAsync()
    {
        return Task.CompletedTask;
    }
}
