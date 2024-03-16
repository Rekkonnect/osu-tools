using OsuRealDifficulty.UI.WinForms.Utilities;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public sealed class CenterAligningFlowLayoutPanel : FlowLayoutPanel
{
    public void AlignAll()
    {
        int totalWidth = GetCurrentItemWidth();
        int remainingWidth = Width - totalWidth;
        int sideWidth = remainingWidth / 2;
        Padding = Padding.WithHorizontal(sideWidth);
    }

    private int GetCurrentItemWidth()
    {
        if (Controls.Count is 0)
            return 0;

        int start = Controls[0].Left;
        int end = Controls[^1].Right;
        int margins = 0;
        for (int i = 0; i < Controls.Count; i++)
        {
            margins += Controls[i].Margin.Horizontal;
        }

        margins -= Controls[0].Margin.Left;
        margins -= Controls[^1].Margin.Right;

        return end - start + margins;
    }
}
