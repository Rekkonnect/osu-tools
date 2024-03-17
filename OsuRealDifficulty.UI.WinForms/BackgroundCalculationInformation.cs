namespace OsuRealDifficulty.UI.WinForms;

public class BackgroundCalculationInformation
{
    public bool IsRunning { get; private set; }
    public int TotalBeatmaps { get; private set; }
    public int ProcessedBeatmaps { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; } = DateTime.MaxValue;

    public TimeSpan ExecutionTime => EndTime - StartTime;
    public TimeSpan CurrentElapsedTime => DateTime.Now - StartTime;
    public TimeSpan EffectiveExecutionTime
    {
        get
        {
            if (IsRunning)
                return CurrentElapsedTime;

            return ExecutionTime;
        }
    }

    public event CalculationEventHandler? InitiationChanged;
    public event CalculationEventHandler? ProcessedBeatmapsChanged;
    public event CalculationEventHandler? AnyChanged
    {
        add
        {
            InitiationChanged += value;
            ProcessedBeatmapsChanged += value;
        }
        remove
        {
            InitiationChanged -= value;
            ProcessedBeatmapsChanged -= value;
        }
    }

    public void Initiate(int totalBeatmaps)
    {
        IsRunning = true;
        TotalBeatmaps = totalBeatmaps;
        ProcessedBeatmaps = 0;
        StartTime = DateTime.Now;
        EndTime = DateTime.MaxValue;

        InitiationChanged?.Invoke(this);
    }
    public void RegisterCalculationComplete()
    {
        ProcessedBeatmaps++;
        ProcessedBeatmapsChanged?.Invoke(this);
    }
    public void FinishCalculation()
    {
        EndTime = DateTime.Now;
        IsRunning = false;
        InitiationChanged?.Invoke(this);
    }

    public delegate void CalculationEventHandler(BackgroundCalculationInformation information);
}
