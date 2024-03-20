using OsuRealDifficulty.UI.WinForms.Utilities;

namespace OsuRealDifficulty.UI.WinForms;

public class ThemeFontForm : Form
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        var fontFamily = ThemeFonts.Instance.MainFontFamily;
        this.RecursivelyReplaceFontFamilyWithMain(fontFamily);
    }
}
