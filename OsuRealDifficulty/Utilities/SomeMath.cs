namespace OsuRealDifficulty.Utilities;

/// <summary>
/// This is some math. For more math, enroll into a CS course.
/// </summary>
public static class SomeMath
{
    public static double Mean(ReadOnlySpan<double> values)
    {
        double result = 0;
        for (int i = 0; i < values.Length; i++)
        {
            result += values[i];
        }

        return result / values.Length;
    }
    public static double Mean2(ReadOnlySpan<double> values)
    {
        double result = 0;
        for (int i = 0; i < values.Length; i++)
        {
            result += values[i].Square();
        }

        result /= values.Length;
        result = Math.Pow(result, 1 / 2D);
        return result;
    }
    public static double Mean(ReadOnlySpan<double> values, double strength)
    {
        if (strength is 1)
            return Mean(values);

        if (strength is 2)
            return Mean2(values);

        double result = 0;
        for (int i = 0; i < values.Length; i++)
        {
            result += values[i].Pow(strength);
        }

        result /= values.Length;
        result = Math.Pow(result, 1 / strength);
        return result;
    }

    public static double Pow(this double value, double exponent)
    {
        return Math.Pow(value, exponent);
    }
    public static double Square(this double value)
    {
        return value * value;
    }
}
