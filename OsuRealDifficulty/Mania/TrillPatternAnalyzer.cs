namespace OsuRealDifficulty.Mania;

public sealed class TrillPatternAnalyzer
    : BaseSingleAnnotationFullAnalyzer<TrillPattern>
{
    public static TrillPatternAnalyzer Instance { get; } = new();

    protected override double SourceChordListWeight => 0.8;

    public override void AnalyzeAnnotations(BeatmapAnnotationAnalysisContext context)
    {
        var chordPressColumns = context.AffectedChordList.NonEmptyPressColumns;
        chordPressColumns.DeconstructLists(out var chords, out var pressColumns);

        const int minTrillLength = 3;

        const double minDistanceRatio = 3D / 5D;
        const double maxDistanceRatio = 5D / 3D;

        const int maxTimeDistance = 750;

        int maxStartIndex = chords.Length - minTrillLength + 1;
        for (int i = 0; i < maxStartIndex; i++)
        {
            AnalyzeCurrentPosition();

            void AnalyzeCurrentPosition()
            {
                // Get the first and second chords' press columns
                var firstPattern = pressColumns[i];
                var secondPattern = pressColumns[i + 1];
                var firstPatternInt = firstPattern.Data;
                var secondPatternInt = secondPattern.Data;

                // Find the common press columns (which are jacks)
                var common = firstPatternInt & secondPatternInt;
                firstPatternInt &= ~common;
                secondPatternInt &= ~common;

                if (firstPatternInt is 0)
                    return;

                if (secondPatternInt is 0)
                    return;

                var thirdPattern = pressColumns[i + 2];
                var firstThirdCommon = firstPatternInt & thirdPattern.Data;

                if (firstThirdCommon is 0)
                    return;

                int firstChordsDistance = chords[i + 1].Offset - chords[i].Offset;
                if (firstChordsDistance > maxTimeDistance)
                    return;

                int thirdChordDistance = chords[i + 2].Offset - chords[i + 1].Offset;
                if (thirdChordDistance > maxTimeDistance)
                    return;

                double thirdChordDistanceRatio = (double)thirdChordDistance / firstChordsDistance;
                if (IsLargeDistanceRatio(thirdChordDistanceRatio))
                    return;

                double baselineDistance = (firstChordsDistance + thirdChordDistance) / 2D;

                firstPatternInt = firstThirdCommon;
                int length = 3;

                // Also attempt to limit the trill scope based on the second pattern
                if (i + 3 < chords.Length)
                {
                    var fourthPattern = pressColumns[i + 3];
                    var secondFourthCommon = secondPatternInt & fourthPattern.Data;

                    int fourthChordDistance = chords[i + 3].Offset - chords[i + 2].Offset;
                    double fourthChordDistanceRatio = fourthChordDistance / baselineDistance;
                    bool acceptFourth = secondFourthCommon is not 0
                        && fourthChordDistance < maxTimeDistance
                        && !IsLargeDistanceRatio(fourthChordDistanceRatio);

                    if (acceptFourth)
                    {
                        length = 4;
                        secondPatternInt = secondFourthCommon;
                    }
                }

                while (true)
                {
                    // First iteration

                    int nextFirst = i + length;
                    bool added = Iterate(nextFirst, firstPatternInt);
                    if (!added)
                        break;

                    // Second iteration

                    int nextSecond = nextFirst + 1;
                    added = Iterate(nextSecond, secondPatternInt);
                    if (!added)
                        break;

                    bool Iterate(int nextIndex, int patternColumns)
                    {
                        if (nextIndex >= chords.Length)
                            return false;

                        var nextPattern = pressColumns[nextIndex];
                        var commonNext = nextPattern.Data & patternColumns;
                        if (commonNext != patternColumns)
                            return false;

                        int nextChordDistance = chords[nextIndex].Offset
                            - chords[nextIndex - 1].Offset;
                        if (nextChordDistance > maxTimeDistance)
                            return false;

                        double nextChordDistanceRatio
                            = nextChordDistance / baselineDistance;
                        if (IsLargeDistanceRatio(nextChordDistanceRatio))
                            return false;

                        length++;
                        return true;
                    }
                }

                int firstPatternNoteCount = firstPatternInt.PopCount();
                int firstPatternTimes = (length + 1) / 2;
                int secondPatternNoteCount = secondPatternInt.PopCount();
                int secondPatternTimes = length / 2;
                int noteCount = firstPatternNoteCount * firstPatternTimes
                    + secondPatternNoteCount * secondPatternTimes;

                int finalIndex = i + length - 1;
                var startOffset = chords[i].Offset;
                var endOffset = chords[finalIndex].Offset;
                var patternColumnsInt = firstPatternInt | secondPatternInt;
                var patternColumns = new BitVector32(patternColumnsInt);

                var trillPattern = new TrillPattern(
                    startOffset,
                    endOffset,
                    noteCount,
                    patternColumns);

                if (trillPattern.NoteCount < minTrillLength)
                {
                    throw new UnreachableException("We have registered a trill with too small note count");
                }

                context.AddAnnotation(trillPattern);
                BeatmapNotePatternAnalyzerHelpers.RemovePressColumns(
                    pressColumns,
                    patternColumns,
                    i,
                    finalIndex);
            }
        }

        static bool IsLargeDistanceRatio(double distanceRatio)
        {
            return distanceRatio
                is < minDistanceRatio
                or > maxDistanceRatio;
        }
    }

    protected override double CalculatePatternAbsoluteValue(TrillPattern pattern)
    {
        var cpsPowered = Math.Pow(pattern.ColumnHitsPerSecond, 1.32);
        var cpsValue = cpsPowered / 10;
        int columnCount = pattern.ColumnCount;
        var intensityDenominator = pattern.NotesPerColumn * 3;
        if (intensityDenominator < 2)
        {
            intensityDenominator = 2;
        }
        double intensity = 2D - (1.5D / (intensityDenominator - 1));
        var value = intensity * cpsValue * Math.Cbrt(columnCount) / 17;
        return value;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Dexterity.Trill;
    }
}
