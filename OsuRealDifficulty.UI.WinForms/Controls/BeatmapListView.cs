﻿using Garyon.Extensions;
using OsuParsers.Database.Objects;
using OsuRealDifficulty.UI.WinForms.Utilities;
using System.ComponentModel;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal sealed class BeatmapListView : SingleItemSelectionChangedListView
{
    private ListViewItem[]? _originalItems;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEnumerable<DbBeatmap> Beatmaps { get; private set; } = [];

    public BeatmapListView()
    {
        DoubleBuffered = true;

        ListViewItemSorter = BeatmapListViewItem.ObjectCountComparer.Instance;
    }

    public void ClearBeatmaps()
    {
        SetBeatmaps([]);
    }

    public void SetBeatmaps(IEnumerable<DbBeatmap> beatmaps)
    {
        Beatmaps = beatmaps;
        SelectedItems.Clear();

        var beatmapListViewItems = beatmaps
            .Select(s => new BeatmapListViewItem(s))
            .ToArray();
        _originalItems = beatmapListViewItems;
        this.SetItems(beatmapListViewItems);
    }

    public void Filter(Predicate<BeatmapListViewItem> itemFilter)
    {
        if (_originalItems is null)
            return;

        var filtered = _originalItems
            .OfType<BeatmapListViewItem>()
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
