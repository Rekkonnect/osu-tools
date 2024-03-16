
namespace OsuRealDifficulty.UI.WinForms.Controls;

public class FadingContainer : Control
{
    public required Control CoveredControl { get; init; }
    public Control? TopControl { get; set; }

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
        Fading.SetFading(false);

        CoveredControl!.Controls.Remove(Fading);
        CoveredControl.Controls.Remove(TopControl);
    }

    public void SwapDisplayTopControl(Control? topControl)
    {
        var previous = TopControl;
        CoveredControl.Controls.Remove(previous);
        TopControl = topControl;
        CoveredControl.Controls.Add(topControl);
        topControl?.BringToFront();
    }
}
