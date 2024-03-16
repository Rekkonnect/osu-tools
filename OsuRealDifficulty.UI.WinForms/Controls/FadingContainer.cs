namespace OsuRealDifficulty.UI.WinForms.Controls;

public class FadingContainer : Control
{
    public required Control CoveredControl { get; init; }
    public Control? TopControl { get; init; }

    public Control? OwningControl => CoveredControl.Parent;

    public FadingControl Fading { get; } = new();

    public void DisplayFade()
    {
        CoveredControl!.Controls.Add(Fading);
        Fading.SetFading(true);
        Fading.BringToFront();

        if (TopControl is not null)
        {
            CoveredControl.Controls.Add(TopControl);
            TopControl.BringToFront();
        }
    }
    public void HideFade()
    {
        CoveredControl!.Controls.Remove(Fading);
        CoveredControl.Controls.Remove(TopControl);
    }
}
