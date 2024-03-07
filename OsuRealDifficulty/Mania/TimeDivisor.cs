namespace OsuRealDifficulty.Mania;

public readonly struct TimeDivisor(int denominator)
{
    public const int Min = 1;
    public const int Max = 16;

    public readonly int Denominator = denominator;

    public static readonly int[] CommonDivisors =
    [
        // Sorted by ascending frequency of the groups

        // Regular
        1,
        2,
        4,
        8,
        16,

        // Triples
        3,
        6,
        9,

        // Irregular
        5,
        7,
    ];

    public static readonly IReadOnlyList<TimeDivisor> CommonDivisorInstances;

    public static TimeDivisor Invalid { get; } = new(0);

    static TimeDivisor()
    {
        CommonDivisorInstances = CommonDivisors
            .Select(s => new TimeDivisor(s))
            .ToArray();
    }

    // Regular divisors are 1 and multiples of 2
    public bool IsRegular => Denominator.PopCount() is 1;
    public bool IsTriple => (Denominator % 3) is 0;

    public bool IsIrregular => !IsRegular && !IsTriple;

    public bool IsInvalid => Denominator is < Min or > Max;

    public TimeDivisor Halve()
    {
        if (Denominator <= Min)
            return this;

        return new(Denominator / 2);
    }
    public TimeDivisor Double()
    {
        if (Denominator >= Max)
            return this;

        return new(Denominator * 2);
    }
}
