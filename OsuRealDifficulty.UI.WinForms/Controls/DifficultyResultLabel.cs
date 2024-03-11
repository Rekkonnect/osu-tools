namespace OsuRealDifficulty.UI.WinForms.Controls;

public class DifficultyResultLabel : BaseDifficultyResultLabel
{
    protected override void EvaluateDifficultyValue()
    {
        if (_difficultyValue.IsCancelled)
        {
            Text = "-";
            return;
        }
        if (_difficultyValue.IsUnknown)
        {
            Text = "?";
            return;
        }
        if (_difficultyValue.IsError)
        {
            Text = "X";
            return;
        }
        if (_difficultyValue.IsPending)
        {
            Text = "...";
            return;
        }

        Text = UIFormattingHelpers.FormatDifficultyValue(_difficultyValue);
    }
}
