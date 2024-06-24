using OsuParsers.Database.Objects;
using OsuRealDifficulty.Mania;
using System.Diagnostics.CodeAnalysis;

namespace OsuRealDifficulty.UI.WinForms.Core;

public class BeatmapDifficultyCalculationCache
{
    private readonly Dictionary<string, FullDifficultyCalculationResult>
        _results = [];

    public int Entries => _results.Count;

    [return: NotNullIfNotNull(nameof(beatmap))]
    public FullDifficultyCalculationResult? GetForBeatmap(DbBeatmap? beatmap)
    {
        if (beatmap is null)
            return null;

        var key = GetKeyForBeatmap(beatmap);
        return _results.GetValueOrDefault(key)
            ?? FullDifficultyCalculationResult.NewPending;
    }

    public void SetForBeatmap(DbBeatmap beatmap, FullDifficultyCalculationResult result)
    {
        var key = GetKeyForBeatmap(beatmap);
        _results[key] = result;
    }

    private static string GetKeyForBeatmap(DbBeatmap beatmap)
    {
        return Path.Combine(beatmap.FolderName, beatmap.FileName);
    }

    public void Clear()
    {
        _results.Clear();
    }
}
