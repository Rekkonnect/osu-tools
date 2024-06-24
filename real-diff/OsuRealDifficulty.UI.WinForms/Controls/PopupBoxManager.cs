namespace OsuRealDifficulty.UI.WinForms.Controls;

public class PopupBoxManager(Control owner)
{
    public Control Owner { get; } = owner;

    private FadingContainer? _currentContainer;
    private PopupBox? _currentShown;

    public void Show(PopupBox box)
    {
        RefreshShownState();

        if (_currentShown is not null)
        {
            box.Show(Owner, _currentContainer!);
        }
        else
        {
            box.Show(Owner);
            _currentContainer = box.FadingContainer;
        }

        _currentShown = box;
    }

    public void HideCurrent()
    {
        if (_currentShown is null)
        {
            return;
        }

        _currentShown.Conclude(DialogResult.None);
        _currentShown = null;
        _currentContainer = null;
    }

    private void RefreshShownState()
    {
        if (_currentShown is { Concluded: true })
        {
            _currentShown = null;
            _currentContainer = null;
        }
    }
}
