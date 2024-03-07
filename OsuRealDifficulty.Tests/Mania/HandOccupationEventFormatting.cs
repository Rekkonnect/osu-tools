using OsuRealDifficulty.Mania;
using System.Text;

namespace OsuRealDifficulty.Tests.Mania;

public static class HandOccupationEventFormatting
{
    public static string FormatAll(HandOccupationList list)
    {
        if (list.Count is 0)
            return "new HandOccupationList()";

        var builder = new StringBuilder();

        builder.AppendLine("""
            new HandOccupationList
            {
            """);

        for (int i = 0; i < list.Count; i++)
        {
            var occupation = list[i];
            var hands = occupation.Occupation;

            const string indentation = "    ";
            builder.Append(indentation);
            builder.AppendLine($"""
                new({occupation.Offset}, HandState.{hands.Left}, HandState.{hands.Right}),
                """);
        }

        builder.AppendLine("""
            }
            """);

        return builder.ToString();
    }
}
