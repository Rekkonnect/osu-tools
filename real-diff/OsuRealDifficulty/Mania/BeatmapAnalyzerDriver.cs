namespace OsuRealDifficulty.Mania;

public sealed class BeatmapAnalyzerDriver(ManiaBeatmapInfo beatmapInfo)
    : BaseBeatmapAnalyzerDriver
{
    private readonly List<IEnumerable<IBeatmapAnalyzer>> _analyzers = new();

    /// <summary>
    /// An action to perform when an exception occurs in an analyzer.
    /// This is triggered the moment an analyzer fails.
    /// </summary>
    public ExceptionAction? ExceptionAction;

    public readonly RefreshRequestChannel AnalyzerExecutionRequestChannel
        = RefreshRequestChannel.Create(new UnboundedChannelOptions
        {
            SingleReader = false,
            SingleWriter = false,
        });

    public BeatmapAnalyzerDriver Add(IBeatmapAnalyzer analyzer)
    {
        return Add([analyzer]);
    }
    public BeatmapAnalyzerDriver Add(IEnumerable<IBeatmapAnalyzer> analyzers)
    {
        _analyzers.Add(analyzers);
        return this;
    }

    public override async Task<DriverExecutionResults> Execute(
        CancellationToken cancellationToken = default)
    {
        const int maxChordCount = 1_000_000;
        if (beatmapInfo.ChordList.Chords.Length > maxChordCount)
        {
            throw new BeatmapTooLargeException(
                beatmapInfo.Beatmap,
                $"Maximum allowed chord list length is {maxChordCount}."
                );
        }

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
            = new ChannelFactory<EsotericDiagnosticBag>(annotationChannelOptions);

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

            var pendingDiagnosticBags = esotericDiagnosticChannel.ConsumeReset(
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

                    await esotericDiagnosticChannel.CurrentChannel.Writer.WriteAsync(
                        context.AnalyzerDiagnostics,
                        cancellationToken);

                    cancellationToken.ThrowIfCancellationRequested();

                    await AnalyzerExecutionRequestChannel.WriteOne(cancellationToken);
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

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

                    // do not await the invocation of the exception action,
                    // this could be blocking our entire application
                    Task.Run(() => ExceptionAction?.Invoke(ex));

#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                }
            }
        }

        ReplacePendingValuesWith(CalculationResult.Unknown);

        if (DifficultyCalculationProfile is not null)
        {
            FullDifficultyCalculationResult =
                DifficultyCalculationProfile.CalculateFullResult(AnalyzedDifficulty);
        }

        return new()
        {
            Diagnostics = finalEsotericDiagnosticBag,
        };
    }

    public class DriverExecutionResults
    {
        public required EsotericDiagnosticBag Diagnostics { get; init; }
    }

    private sealed class ChannelableValueCollectionList<T>(
        UnboundedChannelOptions collectionChannelOptions)
        where T : notnull
    {
        public readonly TypeKeyedList<T> Values = new();

        private readonly ChannelFactory<IEnumerable<T>> _collectionChannelFactory
            = new(collectionChannelOptions);

        public Channel<IEnumerable<T>> CollectionChannel
            => _collectionChannelFactory.CurrentChannel;

        public async Task ConsumeAllFromChannel(CancellationToken cancellationToken)
        {
            var readCollections = _collectionChannelFactory.ConsumeReset(cancellationToken);

            await foreach (var readCollection in readCollections)
            {
                Values.AddRange(readCollection);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }

    // I'm probably abusing channels here
    private sealed class ChannelFactory<T>(UnboundedChannelOptions channelOptions)
    {
        private readonly UnboundedChannelOptions _channelOptions = channelOptions;

        private Channel<T> _channel = Channel.CreateUnbounded<T>(channelOptions);

        public Channel<T> CurrentChannel => _channel;

        public IAsyncEnumerable<T> ConsumeReset(CancellationToken cancellationToken = default)
        {
            _channel.Writer.Complete();
            var result = _channel.Reader.ReadAllAsync(cancellationToken);
            RefreshChannel();
            return result;
        }

        private void RefreshChannel()
        {
            _channel = Channel.CreateUnbounded<T>(_channelOptions);
        }
    }
}
