namespace OsuRealDifficulty.UI.WinForms;

public sealed class LoopingTask(
    int refreshPeriod,
    Action action,
    CancellationToken cancellationToken)
{
    private readonly int _refreshPeriod = refreshPeriod;
    private readonly Action _action = action;
    private readonly CancellationToken _cancellationToken = cancellationToken;

    public void BeginRunForever()
    {
        Task.Run(RunForeverAsync);
    }

    public async Task RunForeverAsync()
    {
        while (true)
        {
            await Task.Delay(_refreshPeriod, _cancellationToken);

            if (_cancellationToken.IsCancellationRequested)
                return;

            _action();
        }
    }

    public static void Begin(
        int refreshPeriod,
        Action action,
        CancellationToken cancellationToken)
    {
        var obj = new LoopingTask(
            refreshPeriod,
            action,
            cancellationToken);
        obj.BeginRunForever();
    }
}
