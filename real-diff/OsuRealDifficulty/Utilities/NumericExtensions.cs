using System.Numerics;

namespace OsuRealDifficulty.Utilities;

public static class NumericExtensions
{
    public static bool IsOdd<T>(this T value)
        where T : IBinaryInteger<T>
    {
        return T.IsOddInteger(value);
    }
    public static bool IsEven<T>(this T value)
        where T : IBinaryInteger<T>
    {
        return T.IsEvenInteger(value);
    }

    public static T ToggleBinary<T>(this T value)
        where T : IBinaryInteger<T>
    {
        if (value == T.Zero)
            return T.One;

        return T.Zero;
    }
    public static T ToggleBinaryRef<T>(this ref T value)
        where T : struct, IBinaryInteger<T>
    {
        return value = value.ToggleBinary();
    }
}
