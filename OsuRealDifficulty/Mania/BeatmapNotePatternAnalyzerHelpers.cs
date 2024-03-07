using System.Collections.Specialized;

namespace OsuRealDifficulty.Mania;

public static class BeatmapNotePatternAnalyzerHelpers
{
    public static void RemovePressColumns(
        BitVector32[] pressColumns,
        BitVector32 removedColumns,
        int startIndex,
        int endIndex)
    {
        for (int i = startIndex; i <= endIndex; i++)
        {
            ref var press = ref pressColumns[i];
            var cleaned = press.Data & ~removedColumns.Data;
            press = new(cleaned);
        }
    }
}
