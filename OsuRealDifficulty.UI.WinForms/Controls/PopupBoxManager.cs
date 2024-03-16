namespace OsuRealDifficulty.UI.WinForms.Controls;

public class PopupBoxManager(Control owner)
{
    public Control Owner { get; } = owner;

    private PopupBox? _currentShown;

    public void Show(PopupBox box)
    {
        HideCurrent();

        _currentShown = box;
        box.Show(Owner);
    }

    public void HideCurrent()
    {
        if (_currentShown is null)
        {
            return;
        }

        _currentShown.Conclude(DialogResult.None);
    }
}
