using OsuRealDifficulty.UI.WinForms.Utilities;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public class CategoryDifficultyResultLabel : BaseDifficultyResultLabel
{
    protected override void EvaluateDifficultyValue()
    {
        var isValid = _difficultyValue.IsValid;
        Visible = isValid;
        if (isValid)
        {
            Text = UIFormattingHelpers.FormatDifficultyValue(_difficultyValue);
            return;
        }
    }
}
