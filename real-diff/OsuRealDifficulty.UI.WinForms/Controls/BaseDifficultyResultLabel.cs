using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public abstract class BaseDifficultyResultLabel : Label
{
    private Color? _initialForeColor;

    protected CalculationResult _difficultyValue = CalculationResult.Pending;

    public double DifficultyValue
    {
        get
        {
            return CalculationResult;
        }
        set
        {
            CalculationResult = value;
        }
    }

    public CalculationResult CalculationResult
    {
        get
        {
            return _difficultyValue;
        }
        set
        {
            _difficultyValue = value;
            EvaluateDifficultyValue();
        }
    }

    public Func<CalculationResult, Color>? ForeColorCalculator;

    protected abstract void EvaluateDifficultyValue();

    protected void AdjustForeColor()
    {
        if (ForeColorCalculator is null)
            return;

        _initialForeColor ??= ForeColor;

        var newFore = ForeColorCalculator?.Invoke(_difficultyValue)
            ?? _initialForeColor.Value;

        ForeColor = newFore;
    }
}
