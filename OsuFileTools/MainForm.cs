using System.Reflection;

namespace OsuFileTools;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        var version = InformationalVersion.InformationalVersionForAssembly(
            Assembly.GetExecutingAssembly())!;
        Text = $"osu! file tools [v{version.Version}]";
    }
}
