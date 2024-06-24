namespace OsuRealDifficulty.Mania;

public sealed class RefreshRequestChannel
{
    private readonly Channel<bool> _channel;

    private RefreshRequestChannel(Channel<bool> channel)
    {
        _channel = channel;
    }

    public static RefreshRequestChannel Create(
        UnboundedChannelOptions channelOptions)
    {
        var backingChannel = Channel.CreateUnbounded<bool>(channelOptions);
        var channel = new RefreshRequestChannel(backingChannel);
        return channel;
    }

    public async Task WriteOne(CancellationToken cancellationToken = default)
    {
        await _channel.Writer.WriteAsync(true, cancellationToken);
    }

    /// <summary>
    /// Consumes all requests and returns whether any was found in the channel.
    /// </summary>
    public async Task<bool> ConsumeAllRequests(CancellationToken cancellationToken = default)
    {
        bool hasAny = false;
        var read = _channel.Reader.ReadAllAsync(cancellationToken);
        await foreach (var item in read)
        {
            hasAny = true;
        }

        cancellationToken.ThrowIfCancellationRequested();
        return hasAny;
    }
}
