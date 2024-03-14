using Garyon.Extensions;
using OsuRealDifficulty.UI.WinForms.Core;
using OsuRealDifficulty.UI.WinForms.Utilities;
using System.ComponentModel;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal sealed class BeatmapSetListView : ListView
{
    private ListViewItem[]? _originalItems;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEnumerable<DbBeatmapSet> BeatmapSets { get; private set; } = [];

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BeatmapSetCount => _originalItems?.Length ?? BeatmapSets.Count();

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
        _originalItems = setListViewItems;
    }

    public void Filter(Predicate<BeatmapSetListViewItem> itemFilter)
    {
        if (_originalItems is null)
            return;

        var filtered = _originalItems
            .OfType<BeatmapSetListViewItem>()
            .WherePredicate(itemFilter)
            .ToArray();
        this.SetItems(filtered);
    }

    public void ResetFilter()
    {
        if (_originalItems is null)
            return;

        this.SetItems(_originalItems);
    }
}
