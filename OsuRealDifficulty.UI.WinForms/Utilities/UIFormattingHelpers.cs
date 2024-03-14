namespace OsuRealDifficulty.UI.WinForms.Utilities;

internal static class UIFormattingHelpers
{
    public static string FormatDifficultyValue(double value)
    {
        return value.ToString("N2");
    }
}
