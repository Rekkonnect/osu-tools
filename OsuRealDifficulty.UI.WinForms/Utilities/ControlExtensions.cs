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
}
