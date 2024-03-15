using OsuRealDifficulty.UI.WinForms.Core;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal sealed class BeatmapSetListViewItem : ListViewItem
{
    public DbBeatmapSet BeatmapSet { get; }

    public BeatmapSetListViewItem(DbBeatmapSet set)
    {
        BeatmapSet = set;

        Text = set.RomanizedOrUnicodeTitle;

        SubItems.Add(set.RomanizedOrUnicodeArtist);
        SubItems.Add(set.Creator);
    }
}
