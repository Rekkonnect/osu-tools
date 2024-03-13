using OsuRealDifficulty.UI.WinForms.Core;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal sealed class BeatmapSetListViewItem : ListViewItem
{
    public DbBeatmapSet BeatmapSet { get; }

    public BeatmapSetListViewItem(DbBeatmapSet set)
    {
        BeatmapSet = set;

        var commonDataBeatmap = set.Beatmaps[0];

        Text = commonDataBeatmap.Title;

        SubItems.Add(commonDataBeatmap.Artist);
        SubItems.Add(commonDataBeatmap.Creator);
    }
}
