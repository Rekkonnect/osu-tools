namespace OsuRealDifficulty.UI.WinForms.Controls;

public sealed partial class PopupBoxButton : Button
{
    public PopupBoxButton()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        FlatStyle = FlatStyle.Flat;
        BackColor = Color.FromArgb(255, 50, 50, 50);
    }
}
