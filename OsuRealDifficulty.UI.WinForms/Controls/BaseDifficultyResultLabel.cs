using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public abstract class BaseDifficultyResultLabel : Label
{
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

    protected abstract void EvaluateDifficultyValue();
}
