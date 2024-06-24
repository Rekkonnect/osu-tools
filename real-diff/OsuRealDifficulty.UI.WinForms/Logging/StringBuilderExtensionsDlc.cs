using Garyon.Extensions;
using System.Text;

namespace OsuRealDifficulty.UI.WinForms.Logging;

public static class StringBuilderExtensionsDlc
{
    public static string Substring(this StringBuilder builder, int startIndex)
    {
        int length = builder.Length - startIndex;
        if (length <= 0)
            return string.Empty;

        return builder.Substring(startIndex, length);
    }
    public static StringBuilder SubstringBuilder(this StringBuilder builder, int startIndex)
    {
        int length = builder.Length - startIndex;
        if (length <= 0)
            return new();

        return builder.SubstringBuilder(startIndex, length);
    }
}
