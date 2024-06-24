namespace OsuRealDifficulty.Mania;

public readonly record struct CalculationResult(double Value)
{
    public const double Pending = -1;
    public const double Error = -2;
    public const double Unknown = -3;
    public const double Cancelled = -4;

    public bool IsPending => Value is Pending;
    public bool IsError => Value is Error;
    public bool IsUnknown => Value is Unknown;
    public bool IsCancelled => Value is Cancelled;

    public bool IsValid => Value >= 0;

    public static implicit operator double(CalculationResult result) => result.Value;
    public static implicit operator CalculationResult(double value) => new(value);
}
