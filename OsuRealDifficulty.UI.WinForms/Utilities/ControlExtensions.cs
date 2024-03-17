using static System.Net.Mime.MediaTypeNames;

namespace OsuRealDifficulty.UI.WinForms.Utilities;

public static class ControlExtensions
{
    public static void SetItems(this ListView listView, ListViewItem[] items)
    {
        var listItems = listView.Items;
        listItems.Clear();
        listItems.AddRange(items);
    }

    public static void SelectIndex(this ListView listView, int index, bool selected = true)
    {
        var listItems = listView.Items;
        listItems[index].Selected = selected;
    }

    public static void EnsureFirstSelectedVisible(this ListView listView)
    {
        var selectedIndices = listView.SelectedIndices;
        if (selectedIndices.Count is 0)
            return;

        int selectedIndex = selectedIndices[0];
        listView.EnsureVisible(selectedIndex);
    }

    public static LayoutSuspension LayoutSuspension(this Control control)
    {
        return new(control);
    }

    public static void SetTextScrollToEnd(this TextBox textBox, string text)
    {
        textBox.Text = text;
        if (text.Length is 0)
            return;

        textBox.Select(text.Length - 1, 0);
        textBox.ScrollToCaret();
    }

    public static void ScrollToEnd(this TextBox textBox)
    {
        int length = textBox.TextLength;
        if (length is 0)
            return;

        textBox.Select(length - 1, 0);
        textBox.ScrollToCaret();
    }
}
