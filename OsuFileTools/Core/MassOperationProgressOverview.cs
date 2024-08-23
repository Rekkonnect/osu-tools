namespace OsuFileTools.Core;

public class MassOperationProgressOverview
{
    public int Succeeded { get; private set; }
    public int Failed { get; private set; }
    public int Skipped { get; private set; }

    public int Total => Succeeded + Failed + Skipped;

    public int ExpectedTotal { get; set; }

    public double ProgressRatio
    {
        get
        {
            if (ExpectedTotal is 0)
                return 0;

            return Total / (double)ExpectedTotal;
        }
    }

    public bool IsComplete => Total == ExpectedTotal;

    public event Action? Updated;

    public void Report(OperationOutcome outcome)
    {
        switch (outcome)
        {
            case OperationOutcome.Success:
                Succeeded++;
                break;
            case OperationOutcome.Fail:
                Failed++;
                break;
            case OperationOutcome.Skip:
                Skipped++;
                break;
        }

        Updated?.Invoke();
    }

    public void Clear()
    {
        Succeeded = 0;
        Failed = 0;
        Skipped = 0;

        Updated?.Invoke();
    }
}
