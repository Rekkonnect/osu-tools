namespace OsuRealDifficulty.Mania;

// TODO: This will be used if we choose to design the dependency graph
// of the analyzers by discovering all the available analyzers and
// determining their dependency graphs at runtime without having to
// manually instantiate all the instanaces.
[AttributeUsage(AttributeTargets.Class)]
public sealed class ExecutionDependsOnAttribute<TAnalyzer> : Attribute
    where TAnalyzer : class, IBeatmapAnalyzer;
