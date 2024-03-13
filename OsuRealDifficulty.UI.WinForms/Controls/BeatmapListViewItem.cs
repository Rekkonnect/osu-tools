using OsuParsers.Database.Objects;
using System.Collections;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal sealed class BeatmapListViewItem : ListViewItem
{
    public DbBeatmap Beatmap { get; }

    public BeatmapListViewItem(DbBeatmap beatmap)
    {
        const string hpOdFormatter = "G2";

        Beatmap = beatmap;

        Text = beatmap.Difficulty;

        SubItems.Add(beatmap.ManiaKeyCount().ToString());
        SubItems.Add(beatmap.HPDrain.ToString(hpOdFormatter));
        SubItems.Add(beatmap.OverallDifficulty.ToString(hpOdFormatter));
        SubItems.Add(beatmap.TotalObjectCount().ToString());
        SubItems.Add(beatmap.CirclesCount.ToString());
        SubItems.Add(beatmap.SlidersCount.ToString());
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

            return x.Beatmap.TotalObjectCount()
                .CompareTo(y.Beatmap.TotalObjectCount());
        }
    }
}
