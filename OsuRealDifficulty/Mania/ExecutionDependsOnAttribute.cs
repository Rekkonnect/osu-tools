namespace OsuRealDifficulty.Mania;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ExecutionDependsOnAttribute<TAnalyzer> : Attribute
    where TAnalyzer : class, IBeatmapAnalyzer;
