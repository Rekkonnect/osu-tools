using Serilog.Core;
using Serilog.Events;

namespace OsuRealDifficulty.UI.WinForms.Logging;

public class InMemoryStringSink : ILogEventSink
{
    public static InMemoryStringSink Instance { get; } = new();

    private string _logString = string.Empty;

    public const int DefaultMaxStringLength = 2 * 1024 * 1024;

    public int MaxStringLength = DefaultMaxStringLength;

    // TODO: Create a buffered sink to avoid too many large concatenations
    public void Emit(LogEvent logEvent)
    {
        var message = logEvent.RenderMessage();
        int newLength = _logString.Length + message.Length;
        if (newLength > MaxStringLength)
        {
            if (message.Length > MaxStringLength)
            {
                int startIndex = message.Length - MaxStringLength;
                _logString = message[startIndex..];
            }
            else
            {
                int startIndex = newLength - MaxStringLength;
                _logString = _logString[startIndex..] + message;
            }
        }
        else
        {
            _logString += message;
        }
    }

    public void Clear()
    {
        _logString = string.Empty;
    }
}
