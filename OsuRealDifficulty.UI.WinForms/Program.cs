using System.Drawing.Text;

namespace OsuRealDifficulty.UI.WinForms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    internal static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        SetDefaultFont();

        Application.Run(new MainForm());
    }

    private static void SetDefaultFont()
    {
        var mainFont = GetMainFont();
        if (mainFont is not null)
        {
            Application.SetDefaultFont(mainFont);
        }
    }

    private static Font? GetMainFont()
    {
        var fonts = ThemeFonts.Instance.Fonts;
        var family = GetDefaultFontFamily(fonts);
        if (family is not null)
        {
            return new Font(family, ThemeFonts.MainFontSize, ThemeFonts.MainFontStyle);
        }

        return null;
    }

    private static FontFamily? GetDefaultFontFamily(PrivateFontCollection resourceFonts)
    {
        var aptosFamily = resourceFonts.Families.FirstOrDefault(s => s.Name is ThemeFonts.MainFontName);
        if (aptosFamily is not null)
            return aptosFamily;

        return resourceFonts.Families.FirstOrDefault();
    }
}
