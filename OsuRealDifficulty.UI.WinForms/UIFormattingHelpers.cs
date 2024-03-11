namespace OsuRealDifficulty.UI.WinForms;

internal static class UIFormattingHelpers
{
    public static string FormatDifficultyValue(double value)
    {
        return value.ToString("N2");
    }
}
