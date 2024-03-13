using Garyon.Extensions;

namespace OsuRealDifficulty.UI.WinForms;

public static class ParsingExtensions
{
    public static int ParseInt32OrDefault(this string s, int defaultValue = 0)
    {
        bool parsed = s.TryParseInt32(out int parsedValue);
        if (!parsed)
            return defaultValue;

        return parsedValue;
    }
}
