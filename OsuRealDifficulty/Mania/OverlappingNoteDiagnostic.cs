namespace OsuRealDifficulty.Mania;

public record OverlappingNoteDiagnostic(NoteIdentifier Identifier, NoteState State)
    : INoteDiagnostic
{
    public DiagnosticSeverity Severity => DiagnosticSeverity.Error;
}
