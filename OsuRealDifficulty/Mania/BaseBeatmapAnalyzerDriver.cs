namespace OsuRealDifficulty.Mania;

public abstract class BaseBeatmapAnalyzerDriver
{
    public FullDifficultyCalculationResult FullDifficultyCalculationResult { get; protected set; }
        = FullDifficultyCalculationResult.NewPending;
    public AnalyzedDifficulty AnalyzedDifficulty
        => FullDifficultyCalculationResult.AnalyzedDifficulty;

    public DifficultyCalculationProfile? DifficultyCalculationProfile { get; set; }

    public abstract Task Execute(CancellationToken cancellationToken);

    protected void AnalyzeAny(
        IBeatmapAnalyzer analyzer,
        CompleteBeatmapAnnotationAnalysisContext context)
    {
        switch (analyzer)
        {
            case IFullBeatmapAnalyzer full:
                Analyze(full, context);
                break;
            case IBeatmapAnnotationAnalyzer annotationAnalyzer:
                Analyze(annotationAnalyzer, context);
                break;
            case IBeatmapDifficultyAnalyzer difficultyAnalyzer:
                Analyze(difficultyAnalyzer, context);
                break;
        }
    }

    protected void Analyze(
        IBeatmapAnnotationAnalyzer analyzer,
        CompleteBeatmapAnnotationAnalysisContext context)
    {
        analyzer.AnalyzeAnnotations(context);
    }

    protected void Analyze(
        IBeatmapDifficultyAnalyzer analyzer,
        CompleteBeatmapAnnotationAnalysisContext context)
    {
        double result = GetCalculationResult(analyzer, context);
        SetCalculationResult(analyzer, result);
    }

    protected void Analyze(
        IFullBeatmapAnalyzer analyzer,
        CompleteBeatmapAnnotationAnalysisContext context)
    {
        analyzer.AnalyzeAnnotations(context);
        double result = GetCalculationResult(analyzer, context);
        SetCalculationResult(analyzer, result);
    }

    protected double GetCalculationResult(
        IBeatmapDifficultyAnalyzer analyzer,
        CompleteBeatmapAnnotationAnalysisContext context)
    {
        double result = analyzer.CalculateDifficultyResult(context);
        if (result < 0)
            return 0;
        return result;
    }

    protected void SetCalculationResult(
        IBeatmapDifficultyAnalyzer analyzer,
        CalculationResult result)
    {
        if (result.Value is double.NegativeInfinity)
        {
            result = CalculationResult.Unknown;
        }
        ref var calculationResult = ref analyzer.CalculationResultRef(AnalyzedDifficulty);
        calculationResult = result;
    }

    protected void TryOverwriteCalculationResult(
        IBeatmapDifficultyAnalyzer analyzer,
        CalculationResult result)
    {
        ref var calculationResult = ref analyzer.CalculationResultRef(AnalyzedDifficulty);
        if (calculationResult.Value is 0)
        {
            calculationResult = result;
        }
    }

    protected void ReplacePendingValuesWith(CalculationResult result)
    {
        ReplacePendingValueWith(ref AnalyzedDifficulty.Dexterity.Speed, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Dexterity.Chord, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Dexterity.Dump, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Dexterity.Trill, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Dexterity.ChordGap, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Dexterity.Singlestream, result);

        ReplacePendingValueWith(ref AnalyzedDifficulty.Jack.Minijack, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Jack.Chordjack, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Jack.Anchor, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Jack.Jackstream, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Jack.Fieldjack, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Jack.DoubleHandJack, result);

        ReplacePendingValueWith(ref AnalyzedDifficulty.Tech.PatternSwitch, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Tech.RhythmIrregularity, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Tech.Flam, result);

        ReplacePendingValueWith(ref AnalyzedDifficulty.Stamina.LongBurst, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Stamina.SteadyRateStream, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Stamina.SingleHandTrill, result);

        ReplacePendingValueWith(ref AnalyzedDifficulty.LongNotes.RiceMix, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.LongNotes.RiceLN, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.LongNotes.Inverse, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.LongNotes.Shield, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.LongNotes.LNShield, result);

        ReplacePendingValueWith(ref AnalyzedDifficulty.Scrolling.Slow, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Scrolling.Fast, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Scrolling.Burst, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Scrolling.Stutter, result);
        ReplacePendingValueWith(ref AnalyzedDifficulty.Scrolling.VisualDensity, result);
    }

    private static void ReplacePendingValueWith(
        ref CalculationResult calculationResultRef,
        CalculationResult result)
    {
        if (calculationResultRef.IsPending)
        {
            calculationResultRef = result;
        }
    }
}
