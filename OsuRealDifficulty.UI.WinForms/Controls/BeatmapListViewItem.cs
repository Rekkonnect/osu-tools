using Garyon.Extensions;
using OsuParsers.Database.Objects;
using OsuParsers.Enums;
using System.Collections;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal sealed class BeatmapListViewItem : ListViewItem
{
    const string hpOdFormatter = "G2";
    const string srFormatter = "N2";

    private Mods _mods;
    private ListViewSubItem _starRatingSubitem;

    public DbBeatmap Beatmap { get; }

    public Mods Mods
    {
        get => _mods;
        set
        {
            _mods = value;
            RefreshStarRating();
        }
    }

    public BeatmapListViewItem(DbBeatmap beatmap)
    {
        Beatmap = beatmap;

        Text = beatmap.Difficulty;

        SubItems.Add(beatmap.ManiaKeyCount().ToString());
        _starRatingSubitem = SubItems.Add(string.Empty);
        SubItems.Add(beatmap.HPDrain.ToString(hpOdFormatter));
        SubItems.Add(beatmap.OverallDifficulty.ToString(hpOdFormatter));
        SubItems.Add(beatmap.TotalObjectCount().ToString());
        SubItems.Add(beatmap.CirclesCount.ToString());
        SubItems.Add(beatmap.SlidersCount.ToString());

        RefreshStarRating();
    }

    private void RefreshStarRating()
    {
        var sr = Beatmap.ManiaStarRating.GetValueOrDefault(_mods);
        _starRatingSubitem.Text = sr.ToString(srFormatter);
    }

    public sealed class ObjectCountComparer
        : IComparer, IComparer<BeatmapListViewItem>
    {
        public static ObjectCountComparer Instance { get; } = new();

        public int Compare(object? x, object? y)
        {
            return Compare(x as BeatmapListViewItem, y as BeatmapListViewItem);
        }

        public int Compare(BeatmapListViewItem? x, BeatmapListViewItem? y)
        {
            if (x is null)
                return -1;
            if (y is null)
                return 1;

            int comparison = x.Beatmap.ManiaKeyCount()
                .CompareTo(y.Beatmap.ManiaKeyCount());

            if (comparison is not 0)
                return comparison;

            var xsr = x.Beatmap.ManiaStarRating.ValueOrDefault(Mods.None);
            var ysr = y.Beatmap.ManiaStarRating.ValueOrDefault(Mods.None);

            comparison = xsr.CompareTo(ysr);

            if (comparison is not 0)
                return comparison;

            return x.Beatmap.TotalObjectCount()
                .CompareTo(y.Beatmap.TotalObjectCount());
        }
    }
}
