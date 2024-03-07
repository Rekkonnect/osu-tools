using OsuRealDifficulty.Mania;
using System.Collections.Specialized;

namespace OsuRealDifficulty.Tests.Mania;

public static class MapAnnotationFormatting
{
    public static string FormatAnnotation(IMapAnnotation annotation, int keys)
    {
        switch (annotation)
        {
            case TrillPattern trillPattern:
                return $"""
                    new TrillPattern({trillPattern.OffsetStart}, {trillPattern.OffsetEnd}, {trillPattern.NoteCount}, Press("{FormatPressString(trillPattern.Columns, keys)}"))
                    """;

            case SinglestreamPattern singlestreamPattern:
                return $"""
                    new SinglestreamPattern({singlestreamPattern.OffsetStart}, {singlestreamPattern.OffsetEnd}, {singlestreamPattern.NoteCount}, {singlestreamPattern.ColumnCount}, {singlestreamPattern.TotalColumnDistance})
                    """;
        }

        throw new NotImplementedException(
            $"The annotation of type {annotation.GetType()} is not supported.");
    }

    private static string FormatPressString(BitVector32 vector, int keys)
    {
        var chars = new char[keys];

        for (int i = 0; i < keys; i++)
        {
            chars[i] = vector.Get(i) ? '-' : ' ';
        }

        return new(chars);
    }
}
