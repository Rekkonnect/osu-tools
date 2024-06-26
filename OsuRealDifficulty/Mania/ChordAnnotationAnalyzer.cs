﻿namespace OsuRealDifficulty.Mania;

public sealed class ChordAnnotationAnalyzer
    : BaseSingleAnnotationFullAnalyzer<ChordAnnotation>
{
    public static ChordAnnotationAnalyzer Instance { get; } = new();

    protected override double SourceChordListWeight => 1;

    public override void AnalyzeAnnotations(BeatmapAnnotationAnalysisContext context)
    {
        var chordPressColumns = context.AffectedChordList.NonEmptyPressColumns;
        chordPressColumns.DeconstructLists(out var chords, out var pressColumns);

        int maxStartIndex = chords.Length;
        for (int i = 0; i < maxStartIndex; i++)
        {
            AnalyzeCurrentPosition();

            void AnalyzeCurrentPosition()
            {
                var column = pressColumns[i];
                int pressCount = column.PopCount();
                if (pressCount <= 1)
                    return;

                var columns = column.Data.GapBits();
                var annotation = new ChordAnnotation(
                    chords[i].Offset,
                    column);
                context.AddAnnotation(annotation);
            }
        }
    }

    public override AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context)
    {
        var baseDifficultyResult = base.CalculateDifficultyResult(context);
        var baseAbsoluteValue = baseDifficultyResult.AbsoluteValue;

        // Adjust for density of chords
        double densityBonus = 0;
        var chordAnnotations = context.Annotations;
        if (chordAnnotations.Count is 0)
            return AnalysisDifficultyValue.NormalizedZero;

        var timeDifferences = new double[chordAnnotations.Count - 1];
        for (int i = 1; i < chordAnnotations.Count; i++)
        {
            const int baseMinDensityDistance = 350;
            const int densityDistanceBuffPerNote = 35;

            var previous = chordAnnotations[i - 1];
            var next = chordAnnotations[i];
            if (previous is not ChordAnnotation previousChord)
                throw new UnreachableException("Must have been ChordAnnotation");
            if (next is not ChordAnnotation nextChord)
                throw new UnreachableException("Must have been ChordAnnotation");

            int totalNotes = previousChord.NoteCount + nextChord.NoteCount;
            int minDensityDistance = baseMinDensityDistance
                + totalNotes * densityDistanceBuffPerNote;
            int distance = nextChord.Offset - previousChord.Offset;
            if (distance < minDensityDistance)
                continue;
        }

        var totalAbsoluteValue = baseAbsoluteValue + densityBonus;
        return new(totalAbsoluteValue);
    }

    protected override double CalculatePatternAbsoluteValue(ChordAnnotation annotation)
    {
        double noteCount = annotation.NoteCount * 0.3;
        double gap = annotation.ColumnGaps * 0.4 + 0.25;
        return (noteCount.Pow(0.63) + gap.Pow(0.42)) / 8;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Dexterity.Chord;
    }
}
