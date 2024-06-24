namespace OsuRealDifficulty.Mania;

/// <summary>
/// A full beatmap analyzer is responsible for both the analysis
/// producing annotations, and for calculating the difficulty value for a
/// specific skill. The annotations from the same pass will be available for
/// the calculation of the skill that is being analyzed.
/// This incorporates logic from both
/// <see cref="IBeatmapAnnotationAnalyzer"/> and
/// <see cref="IBeatmapDifficultyAnalyzer"/>.
/// </summary>
public interface IFullBeatmapAnalyzer
    : IBeatmapAnnotationAnalyzer, IBeatmapDifficultyAnalyzer
{
}

/// <summary>
/// Denotes that an analyzer is responsible for analyzing the notes of the beatmap.
/// </summary>
public interface IBeatmapNoteAnalyzer;

/// <summary>
/// Denotes that an analyzer is responsible for analyzing the timing points of the beatmap.
/// This is especially important to accurately note, as timing points are often not
/// included in testing chord lists, and therefore analyzers about timing points will have
/// no information to operate on.
/// </summary>
public interface IBeatmapTimingPointAnalyzer;

public interface IFullBeatmapNoteAnalyzer
    : IFullBeatmapAnalyzer, IBeatmapNoteAnalyzer;
