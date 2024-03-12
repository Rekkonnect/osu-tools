namespace OsuRealDifficulty.UI.WinForms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        var fontFamily = ThemeFonts.Instance.MainFontFamily;
        RecursivelyReplaceFontFamilyWithMain(this, fontFamily);
    }

    private static void RecursivelyReplaceFontFamilyWithMain(
        Control control,
        FontFamily? mainFontFamily)
    {
        if (mainFontFamily is null)
            return;

        control.SuspendLayout();

        if (control.Font.FontFamily?.Name == mainFontFamily.Name)
        {
            control.Font = control.Font.WithFamily(mainFontFamily);
        }

        foreach (Control child in control.Controls)
        {
            RecursivelyReplaceFontFamilyWithMain(child, mainFontFamily);
        }

        control.ResumeLayout();
    }
}
