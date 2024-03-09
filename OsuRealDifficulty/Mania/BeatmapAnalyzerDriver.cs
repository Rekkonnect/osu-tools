using System.Threading.Channels;

namespace OsuRealDifficulty.Mania;

public abstract class BaseBeatmapAnalyzerDriver
{
    public AnalyzedDifficulty AnalyzedDifficulty { get; } = AnalyzedDifficulty.NewPending;

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
        double result = analyzer.CalculateDifficultyResult(context);
        SetCalculationResult(analyzer, result);
    }

    protected void Analyze(
        IFullBeatmapAnalyzer analyzer,
        CompleteBeatmapAnnotationAnalysisContext context)
    {
        analyzer.AnalyzeAnnotations(context);
        double result = analyzer.CalculateDifficultyResult(context);
        SetCalculationResult(analyzer, result);
    }

    protected void SetCalculationResult(
        IBeatmapDifficultyAnalyzer analyzer,
        CalculationResult result)
    {
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
}

public sealed class BeatmapAnalyzerDriver(ManiaBeatmapInfo beatmapInfo)
    : BaseBeatmapAnalyzerDriver
{
    private readonly List<IEnumerable<IBeatmapAnalyzer>> _analyzers = new();

    /// <summary>
    /// An action to perform when an exception occurs in an analyzer.
    /// This is triggered the moment an analyzer fails.
    /// </summary>
    public ExceptionAction? ExceptionAction;

    public BeatmapAnalyzerDriver Add(IBeatmapAnalyzer analyzer)
    {
        return Add([analyzer]);
    }
    public BeatmapAnalyzerDriver Add(IEnumerable<IBeatmapAnalyzer> analyzers)
    {
        _analyzers.Add(analyzers);
        return this;
    }

    public override async Task Execute(CancellationToken cancellationToken = default)
    {
        var annotationChannelOptions = new UnboundedChannelOptions
        {
            SingleWriter = false,
            SingleReader = true,
            AllowSynchronousContinuations = true,
        };

        var sourceChordListChannelable
            = new ChannelableValueCollectionList<IMapAnnotation>(
                annotationChannelOptions);
        var normalizedChordListChannelable
            = new ChannelableValueCollectionList<IMapAnnotation>(
                annotationChannelOptions);

        var esotericDiagnosticChannel
            = Channel.CreateUnbounded<EsotericDiagnosticBag>(annotationChannelOptions);

        var finalEsotericDiagnosticBag = new EsotericDiagnosticBag();

        var baseCompleteContext = new CompleteBeatmapAnnotationAnalysisContext
        {
            BeatmapInfo = beatmapInfo,
            CommittedSourceChordListAnnotations = sourceChordListChannelable.Values,
            CommittedNormalizedChordListAnnotations = normalizedChordListChannelable.Values,
            SourceChordListAnnotations = null!,
            NormalizedChordListAnnotations = null!,
            CancellationToken = cancellationToken,
            AnalyzerDiagnostics = null!,
        };

        foreach (var group in _analyzers)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await Parallel.ForEachAsync(group, ExecuteSingle);
            cancellationToken.ThrowIfCancellationRequested();

            await sourceChordListChannelable.ConsumeAllFromChannel(
                cancellationToken);
            await normalizedChordListChannelable.ConsumeAllFromChannel(
                cancellationToken);

            var pendingDiagnosticBags = esotericDiagnosticChannel.Reader.ReadAllAsync(
                cancellationToken);
            await foreach (var diagnosticBag in pendingDiagnosticBags)
            {
                finalEsotericDiagnosticBag.AddRange(diagnosticBag.Diagnostics);
            }

            async ValueTask ExecuteSingle(
                IBeatmapAnalyzer analyzer,
                CancellationToken cancellationToken)
            {
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var context = baseCompleteContext with
                    {
                        SourceChordListAnnotations = [],
                        NormalizedChordListAnnotations = [],
                        AnalyzerDiagnostics = new(),
                    };
                    AnalyzeAny(analyzer, context);

                    cancellationToken.ThrowIfCancellationRequested();

                    await sourceChordListChannelable.CollectionChannel.Writer.WriteAsync(
                        context.SourceChordListAnnotations, cancellationToken);
                    await normalizedChordListChannelable.CollectionChannel.Writer.WriteAsync(
                        context.NormalizedChordListAnnotations, cancellationToken);

                    await esotericDiagnosticChannel.Writer.WriteAsync(
                        context.AnalyzerDiagnostics,
                        cancellationToken);

                    cancellationToken.ThrowIfCancellationRequested();
                }
                catch (OperationCanceledException)
                {
                    if (analyzer is IBeatmapDifficultyAnalyzer difficultyAnalyzer)
                    {
                        TryOverwriteCalculationResult(
                            difficultyAnalyzer,
                            CalculationResult.Cancelled);
                    }
                }
                catch (Exception ex)
                {
                    if (analyzer is IBeatmapDifficultyAnalyzer difficultyAnalyzer)
                    {
                        SetCalculationResult(
                            difficultyAnalyzer,
                            CalculationResult.Error);
                    }

                    // Do not await the invocation of the exception action,
                    // this could be blocking our entire application
                    ExceptionAction?.BeginInvoke(ex, null, null);
                }
            }
        }
    }

    private sealed class ChannelableValueCollectionList<T>(
        UnboundedChannelOptions collectionChannelOptions)
        where T : notnull
    {
        public readonly TypeKeyedList<T> Values = new();

        public readonly Channel<IEnumerable<T>> CollectionChannel
            = Channel.CreateUnbounded<IEnumerable<T>>(
                collectionChannelOptions);

        public async Task ConsumeAllFromChannel(CancellationToken cancellationToken)
        {
            var readCollections = CollectionChannel.Reader
                .ReadAllAsync(cancellationToken);

            await foreach (var readCollection in readCollections)
            {
                Values.AddRange(readCollection);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}
