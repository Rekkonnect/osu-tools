using System.Reflection.Metadata.Ecma335;

namespace OsuRealDifficulty.Mania;

public sealed class JackstreamPatternDifficultyAnalyzer
    : DiscerningChordListDifficultyAnalyzer
{
    public static JackstreamPatternDifficultyAnalyzer Instance { get; } = new();

    // most jacks on the special key are not meant to be replaced
    protected override double SourceChordListWeight => 0.7;

    public override AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context)
    {
        var annotations = context.CommittedAnnotations
            .OfType<JackstreamAnnotation>()
            .ToList();

        return DifficultyCalculationAlgorithms.Aggregation.SmallDoubleMeans(
            annotations,
            AbsoluteValueForJackstream);
    }

    private double AbsoluteValueForJackstream(JackstreamAnnotation jackstream)
    {
        double averageTimeDistance = jackstream.AverageTimeDistance;
        double distanceMultiplier = Math.Pow(250 / averageTimeDistance, 1.3);
        double hitCountMultiplier = Math.Pow(Math.Log(jackstream.HitCount, 6), 0.6 + distanceMultiplier);
        double columnBase = jackstream.ColumnCount + 1;
        double columnCountMultiplier = Math.Pow(columnBase, 0.41);
        return distanceMultiplier * columnCountMultiplier * hitCountMultiplier / 6;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Jack.Jackstream;
    }
}

public sealed class DoubleHandJackPatternDifficultyAnalyzer
    : DiscerningChordListDifficultyAnalyzer
{
    public static DoubleHandJackPatternDifficultyAnalyzer Instance { get; } = new();

    // most jacks on the special key are not meant to be replaced
    protected override double SourceChordListWeight => 0.7;

    public override AnalysisDifficultyValue CalculateDifficultyResult(
        BeatmapAnnotationAnalysisContext context)
    {
        return AnalysisDifficultyValue.NormalizedZero;
    }

    public override ref CalculationResult CalculationResultRef(
        AnalyzedDifficulty difficulty)
    {
        return ref difficulty.Jack.DoubleHandJack;
    }
}
