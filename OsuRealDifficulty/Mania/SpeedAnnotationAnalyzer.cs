namespace OsuRealDifficulty.Mania;

public sealed class SpeedAnnotationAnalyzer
    : IBeatmapDifficultyAnalyzer
{
    public static SpeedAnnotationAnalyzer Instance { get; } = new();

    public double CalculateDifficultyResult(CompleteBeatmapAnnotationAnalysisContext context)
    {
        var sourceChordInfo = context.BeatmapInfo.ChordListInfo;
        var columnPressInfo = sourceChordInfo.NonEmptyPressColumns;
        int chordCount = columnPressInfo.Count;
        if (chordCount < 2)
            return 0;

        columnPressInfo.DeconstructLists(out var chords, out var pressColumns);
        int totalNotes = context.BeatmapInfo.HitObjectCount;
        var notesPerChord = (double)totalNotes / chordCount;
        var timeDifferences = new double[chordCount - 1];
        for (int i = 1; i < chordCount; i++)
        {
            timeDifferences[i - 1] = chords[i].Offset - chords[i - 1].Offset;
        }

        double timeDifferenceMean2 = SomeMath.Mean2(timeDifferences);
        double assumedPlayTime = timeDifferenceMean2 * timeDifferences.Length;
        double assumedPlayTimeBonus = Math.Max(1, Math.Log(assumedPlayTime) / 4);
        double timeDifferenceMeanScore = Math.Pow(500 / timeDifferenceMean2, 1.25);
        double mainDifficulty = timeDifferenceMeanScore * notesPerChord * assumedPlayTimeBonus;

        // Burst bonus
        double burstBonus = 0;
        for (int i = 0; i < timeDifferences.Length; i++)
        {
            double ratio = timeDifferences[i] / timeDifferenceMean2;
            if (ratio < 1)
                continue;

            double bonusMultiplier = Math.Pow(1.05, ratio);
            burstBonus += bonusMultiplier * timeDifferenceMeanScore;
        }

        return mainDifficulty + burstBonus;
    }

    public ref CalculationResult CalculationResultRef(AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Dexterity.Speed;
    }
}
