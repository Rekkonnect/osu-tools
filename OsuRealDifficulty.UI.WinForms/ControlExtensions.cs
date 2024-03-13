namespace OsuRealDifficulty.UI.WinForms;

public static class ControlExtensions
{
    public static void SetItems(this ListView listView, ListViewItem[] items)
    {
        var listItems = listView.Items;
        listItems.Clear();
        listItems.AddRange(items);
    }
}
