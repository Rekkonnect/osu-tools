using System.Threading.Channels;

namespace OsuRealDifficulty.Mania;

public sealed class BeatmapAnnotationAnalysisDriver(ManiaBeatmapInfo beatmapInfo)
{
    private readonly List<IEnumerable<IBeatmapAnnotationAnalyzer>> _analyzers = new();

    public AnalyzedDifficulty AnalyzedDifficulty { get; } = AnalyzedDifficulty.NewPending;

    /// <summary>
    /// An action to perform when an exception occurs in an analyzer.
    /// This is triggered the moment an analyzer fails.
    /// </summary>
    public ExceptionAction? ExceptionAction;

    public BeatmapAnnotationAnalysisDriver Add(IBeatmapAnnotationAnalyzer analyzer)
    {
        return Add([analyzer]);
    }
    public BeatmapAnnotationAnalysisDriver Add(IEnumerable<IBeatmapAnnotationAnalyzer> analyzers)
    {
        _analyzers.Add(analyzers);
        return this;
    }

    public async Task Execute(CancellationToken cancellationToken = default)
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

        var baseCompleteContext = new CompleteBeatmapAnnotationAnalysisContext
        {
            BeatmapInfo = beatmapInfo,
            CommittedSourceChordListAnnotations = sourceChordListChannelable.Values,
            CommittedNormalizedChordListAnnotations = normalizedChordListChannelable.Values,
            SourceChordListAnnotations = null!,
            NormalizedChordListAnnotations = null!,
            CancellationToken = cancellationToken,
        };

        foreach (var group in _analyzers)
        {
            await Parallel.ForEachAsync(group, ExecuteSingle);
            cancellationToken.ThrowIfCancellationRequested();

            await sourceChordListChannelable.ConsumeAllFromChannel(
                cancellationToken);
            await normalizedChordListChannelable.ConsumeAllFromChannel(
                cancellationToken);

            async ValueTask ExecuteSingle(
                IBeatmapAnnotationAnalyzer analyzer,
                CancellationToken cancellationToken)
            {
                try
                {
                    var context = baseCompleteContext with
                    {
                        SourceChordListAnnotations = [],
                        NormalizedChordListAnnotations = [],
                    };
                    Analyze(analyzer, context);

                    await sourceChordListChannelable.CollectionChannel.Writer.WriteAsync(
                        context.SourceChordListAnnotations, cancellationToken);
                    await normalizedChordListChannelable.CollectionChannel.Writer.WriteAsync(
                        context.NormalizedChordListAnnotations, cancellationToken);
                }
                catch (Exception ex)
                {
                    SetCalculationResult(analyzer, CalculationResult.Error);

                    // Do not await the invocation of the exception action,
                    // this could be blocking our entire application
                    ExceptionAction?.BeginInvoke(ex, null, null);
                }
            }
        }
    }

    private void Analyze(
        IBeatmapAnnotationAnalyzer analyzer,
        CompleteBeatmapAnnotationAnalysisContext context)
    {
        analyzer.Analyze(context);
        double result = analyzer.CalculateDifficultyResult(context);
        SetCalculationResult(analyzer, result);
    }

    private void SetCalculationResult(
        IBeatmapAnnotationAnalyzer analyzer,
        CalculationResult result)
    {
        ref var calculationResult = ref analyzer.CalculationResultRef(AnalyzedDifficulty);
        calculationResult = result;
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
