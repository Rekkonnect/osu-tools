namespace OsuRealDifficulty.Mania;

public sealed class ChordGapAnnotationAnalyzer
    : IFullBeatmapNoteAnalyzer
{
    public static ChordGapAnnotationAnalyzer Instance { get; } = new();

    public void AnalyzeAnnotations(BeatmapAnnotationAnalysisContext context)
    {
        var chordPressColumns = context.AffectedChordList.NonEmptyPressColumns;
        chordPressColumns.DeconstructLists(out var chords, out var pressColumns);

        int maxStartIndex = chords.Length;
        for (int i = 0; i < maxStartIndex; i++)
        {
            AnalyzeCurrentPosition();
            AnalyzeCurrentWithPreviousPosition();

            void AnalyzeCurrentPosition()
            {
                var pressColumn = pressColumns[i];
                int gapSize = pressColumn.Data.GapBits();
                if (gapSize is 0)
                    return;

                var annotation = new ChordGapAnnotation(chords[i].Offset, gapSize);
                context.AddAnnotation(annotation);
            }
            void AnalyzeCurrentWithPreviousPosition()
            {
                if (i is 0)
                    return;

                int offsetStart = chords[i].Offset;
                int offsetEnd = chords[i - 1].Offset;

                const int maxTimeDifference = 350;
                int offsetDifference = offsetEnd - offsetStart;
                if (offsetDifference > maxTimeDifference)
                    return;

                var pressColumn = pressColumns[i];
                var previousPressColumn = pressColumns[i - 1];
                int chordCombination = pressColumn.Data | previousPressColumn.Data;
                int gapSize = chordCombination.GapBits();
                if (gapSize is 0)
                    return;

                var annotation = new ChordGapPatternAnnotation(
                    offsetStart,
                    offsetEnd,
                    gapSize);
                context.AddAnnotation(annotation);
            }
        }
    }

    public double CalculateDifficultyResult(CompleteBeatmapAnnotationAnalysisContext context)
    {
        var sourceContext = context.ContextForSourceChordList();
        var annotations = sourceContext.Annotations;

        double singleChordAbsoluteValue = 0;
        double doubleChordAbsoluteValue = 0;
        foreach (var annotation in annotations)
        {
            switch (annotation)
            {
                case ChordGapAnnotation chordGap:
                {
                    double localAbsoluteValue = CalculatePatternAbsoluteValue(chordGap);
                    singleChordAbsoluteValue += localAbsoluteValue;
                    break;
                }

                case ChordGapPatternAnnotation chordGapPattern:
                {
                    double localAbsoluteValue = CalculatePatternAbsoluteValue(chordGapPattern);
                    doubleChordAbsoluteValue += localAbsoluteValue;
                    break;
                }

                default:
                    break;
            }
        }

        double totalAbsoluteValue = singleChordAbsoluteValue + doubleChordAbsoluteValue;
        var totalValue = new AnalysisDifficultyValue(totalAbsoluteValue);
        return totalValue.NormalizedValue;
    }

    private double CalculatePatternAbsoluteValue(ChordGapAnnotation annotation)
    {
        double noteCount = annotation.GapSize;
        return noteCount.Pow(0.9);
    }

    private double CalculatePatternAbsoluteValue(ChordGapPatternAnnotation annotation)
    {
        double offsetMultiplier = 100D / annotation.Length;
        double noteCount = annotation.GapSize;
        return noteCount.Pow(0.9) * offsetMultiplier;
    }

    public ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Dexterity.Chord;
    }
}
