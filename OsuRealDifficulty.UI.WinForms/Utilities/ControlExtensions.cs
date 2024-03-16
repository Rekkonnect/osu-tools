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
        textBox.Select(text.Length - 1, 0);
        textBox.ScrollToCaret();
    }

    public static void ScrollToEnd(this TextBox textBox)
    {
        textBox.Select(textBox.TextLength - 1, 0);
        textBox.ScrollToCaret();
    }
}
