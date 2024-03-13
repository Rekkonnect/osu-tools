using OsuParsers.Database.Objects;
using System.ComponentModel;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal sealed class BeatmapListView : ListView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEnumerable<DbBeatmap> Beatmaps { get; private set; } = [];

    public BeatmapListView()
    {
        DoubleBuffered = true;

        ListViewItemSorter = BeatmapListViewItem.ObjectCountComparer.Instance;
    }

    public void SetBeatmaps(IEnumerable<DbBeatmap> beatmaps)
    {
        Beatmaps = beatmaps;

        var beatmapListViewItems = beatmaps
            .Select(s => new BeatmapListViewItem(s))
            .ToArray();
        this.SetItems(beatmapListViewItems);
    }
}
