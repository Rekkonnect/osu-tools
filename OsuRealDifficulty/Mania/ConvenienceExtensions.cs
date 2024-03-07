using System.Collections.Specialized;
using System.Numerics;

namespace OsuRealDifficulty.Mania;

public static class ConvenienceExtensions
{
    public static T? TransformOrSame<T>(this T source, Func<T, T?> transformer)
        where T : class?
    {
        return transformer(source) ?? source;
    }

    public static int PopCount(this int value)
    {
        return BitOperations.PopCount((uint)value);
    }
    public static int PopCount(this uint value)
    {
        return BitOperations.PopCount(value);
    }
    public static int PopCount(this long value)
    {
        return BitOperations.PopCount((ulong)value);
    }
    public static int PopCount(this ulong value)
    {
        return BitOperations.PopCount(value);
    }

    public static uint UInt(this BitVector32 vector) => (uint)vector.Data;

    public static bool Get(this BitVector32 vector, int index)
    {
        int mask = 1 << index;
        return vector[mask];
    }
    public static void Set(this ref BitVector32 vector, int index, bool value)
    {
        int mask = 1 << index;
        vector[mask] = value;
    }

    public static BitVector32 And(this BitVector32 vector, BitVector32 other)
    {
        return new(vector.Data & other.Data);
    }
    public static BitVector32 Or(this BitVector32 vector, BitVector32 other)
    {
        return new(vector.Data | other.Data);
    }
    public static BitVector32 Xor(this BitVector32 vector, BitVector32 other)
    {
        return new(vector.Data ^ other.Data);
    }

    public static int PopCount(this BitVector32 vector)
    {
        return vector.Data.PopCount();
    }

    public static int FirstBitIndex(this BitVector32 vector)
    {
        return BitOperations.TrailingZeroCount(vector.Data);
    }

    public static int LastBitIndex(this BitVector32 vector)
    {
        return 31 - BitOperations.LeadingZeroCount((uint)vector.Data);
    }
}
