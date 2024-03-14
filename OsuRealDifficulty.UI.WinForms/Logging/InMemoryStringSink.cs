using Garyon.Extensions;
using Serilog.Core;
using Serilog.Events;
using System.Text;

namespace OsuRealDifficulty.UI.WinForms.Logging;

public class InMemoryStringSink : ILogEventSink
{
    public static InMemoryStringSink Instance { get; } = new();

    private string _logString = string.Empty;

    public const int DefaultMaxStringLength = 2 * 1024 * 1024;

    public int MaxStringLength = DefaultMaxStringLength;

    public void Emit(LogEvent logEvent)
    {
        var message = logEvent.RenderMessage();
        EmitSingleMessage(message);
    }

    private void EmitSingleMessage(string message)
    {
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

    internal void EmitStringBuilder(StringBuilder builder)
    {
        // we completely overwrite the existing buffer
        if (builder.Length > MaxStringLength)
        {
            int startIndex = builder.Length - MaxStringLength;
            _logString = builder.SubstringLast(startIndex);
            return;
        }

        // we overwrite part of the buffer
        int newLength = _logString.Length + builder.Length;
        var newMessageBuilder = new StringBuilder(MaxStringLength);
        if (newLength > MaxStringLength)
        {
            int startIndex = newLength - MaxStringLength;
            int originalStringLength = _logString.Length - startIndex;
            newMessageBuilder.Append(_logString, startIndex, originalStringLength);
        }
        else
        {
            newMessageBuilder.Append(_logString);
        }

        // append the message
        newMessageBuilder.Append(builder);
        _logString = newMessageBuilder.ToString();
    }

    public void Clear()
    {
        _logString = string.Empty;
    }
}
