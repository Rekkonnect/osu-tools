namespace OsuRealDifficulty.UI.WinForms;

internal static class ThemeFontHelpers
{
    public static void RecursivelyReplaceFontFamilyWithMain(
        this Control control,
        FontFamily? mainFontFamily)
    {
        if (mainFontFamily is null)
            return;

        bool usingIntended = IsUsingTargetFontFamily(control.Font, mainFontFamily);
        bool needsReplacement = !usingIntended
            && control.Font.OriginalFontName == mainFontFamily.Name;

        if (needsReplacement)
        {
            control.SuspendLayout();
            control.Font = control.Font.WithFamily(mainFontFamily);
        }

        foreach (Control child in control.Controls)
        {
            RecursivelyReplaceFontFamilyWithMain(child, mainFontFamily);
        }

        if (needsReplacement)
        {
            control.ResumeLayout();
        }
    }

    private static bool IsUsingTargetFontFamily(
        Font usedFont,
        FontFamily targetFamily)
    {
        return usedFont.FontFamily == targetFamily
            && usedFont.OriginalFontName == targetFamily.Name;
    }
}
