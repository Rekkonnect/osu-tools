using Garyon.Extensions;
using OsuRealDifficulty.UI.WinForms.Core;
using OsuRealDifficulty.UI.WinForms.Utilities;
using System.ComponentModel;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal sealed class BeatmapSetListView : SingleItemSelectionChangedListView
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

    public void SelectBeatmapSet(DbBeatmapSet? dbBeatmapSet)
    {
        if (dbBeatmapSet is null)
        {
            SelectedIndices.Clear();
            return;
        }

        var item = GetBeatmapSetListViewItem(dbBeatmapSet);
        if (item is not null)
        {
            this.SelectIndex(item.Index);
        }
    }

    public BeatmapSetListViewItem? GetBeatmapSetListViewItem(DbBeatmapSet? dbBeatmapSet)
    {
        if (dbBeatmapSet is null)
            return null;

        // This will fuck me over, won't it
        var item = Items
            .OfType<BeatmapSetListViewItem>()
            .FirstOrDefault(beatmapSetListViewItem =>
            {
                var set = beatmapSetListViewItem.BeatmapSet;
                if (set.SetId != dbBeatmapSet.SetId)
                {
                    return false;
                }

                // A set ID > 0 means that the set is submitted and officially ranked
                // So we don't have to compare potentially unrelated sets with the same
                // invented negative ID (consult DbBeatmapSetDatabase)
                if (set.SetId > 0)
                {
                    return true;
                }

                return set.RomanizedOrUnicodeTitle == dbBeatmapSet.RomanizedOrUnicodeTitle
                    && set.RomanizedOrUnicodeArtist == dbBeatmapSet.RomanizedOrUnicodeArtist
                    && set.Creator == dbBeatmapSet.Creator
                    ;
            });

        return item;
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
