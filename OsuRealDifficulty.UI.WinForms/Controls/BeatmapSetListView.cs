using OsuRealDifficulty.UI.WinForms.Core;
using System.ComponentModel;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal sealed class BeatmapSetListView : ListView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEnumerable<DbBeatmapSet> BeatmapSets { get; private set; } = [];

    public BeatmapSetListView()
    {
        DoubleBuffered = true;
    }

    public void SetBeatmapSets(IEnumerable<DbBeatmapSet> sets)
    {
        BeatmapSets = sets;

        var setListViewItems = sets
            .Select(s => new BeatmapSetListViewItem(s))
            .ToArray();
        this.SetItems(setListViewItems);
    }
}
