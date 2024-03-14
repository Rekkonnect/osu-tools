using System.Runtime.CompilerServices;

namespace OsuRealDifficulty;

public sealed class EsotericDiagnosticBag
{
    private readonly List<EsotericDiagnostic> _diagnostics = [];

    public IReadOnlyList<EsotericDiagnostic> Diagnostics => _diagnostics;

    public void AddEsotericDiagnostic(
        string message,
        [CallerLineNumber] int callerLine = 0,
        [CallerFilePath] string callerFile = "",
        [CallerMemberName] string callerName = "")
    {
        var diagnostic = new EsotericDiagnostic(message, callerLine, callerFile, callerName);
        _diagnostics.Add(diagnostic);
    }

    public void Add(EsotericDiagnostic diagnostic)
    {
        _diagnostics.Add(diagnostic);
    }

    public void AddRange(IEnumerable<EsotericDiagnostic> diagnostics)
    {
        foreach (var diagnostic in diagnostics)
        {
            Add(diagnostic);
        }
    }
}

public sealed class EsotericDiagnostic(
    string message,
    [CallerLineNumber] int callerLine = 0,
    [CallerFilePath] string callerFile = "",
    [CallerMemberName] string callerName = "")
{
    public string Message { get; } = message;
    public int CallerLine { get; } = callerLine;
    public string CallerFile { get; } = callerFile;
    public string CallerName { get; } = callerName;
}
