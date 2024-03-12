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
        this.RecursivelyReplaceFontFamilyWithMain(fontFamily);
    }
}
