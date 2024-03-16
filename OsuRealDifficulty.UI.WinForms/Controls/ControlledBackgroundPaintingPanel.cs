namespace OsuRealDifficulty.UI.WinForms.Controls;

public class ControlledBackgroundPaintingPanel : Panel
{
    private bool _painted = false;

    protected override void OnBackColorChanged(EventArgs e)
    {
        _painted = false;
        base.OnBackColorChanged(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // avoid painting anything
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        if (_painted)
            return;

        _painted = true;
        base.OnPaintBackground(e);
    }
}
