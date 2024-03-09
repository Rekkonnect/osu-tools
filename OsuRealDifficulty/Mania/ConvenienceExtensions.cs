using System.Collections.Specialized;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace OsuRealDifficulty.Mania;

// High level
public static partial class ConvenienceExtensions
{
    public static T? TransformOrSame<T>(this T source, Func<T, T?> transformer)
        where T : class?
    {
        return transformer(source) ?? source;
    }

    public static TResult[] SelectArray<TSource, TResult>(
        this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        return source.Select(selector).ToArray();
    }
}

// Low level
static partial class ConvenienceExtensions
{
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

    public static int LeadingZeroCount(this int value)
    {
        return BitOperations.LeadingZeroCount((uint)value);
    }
    public static int LeadingZeroCount(this uint value)
    {
        return BitOperations.LeadingZeroCount(value);
    }
    public static int LeadingZeroCount(this long value)
    {
        return BitOperations.LeadingZeroCount((ulong)value);
    }
    public static int LeadingZeroCount(this ulong value)
    {
        return BitOperations.LeadingZeroCount(value);
    }

    public static int TrailingZeroCount(this int value)
    {
        return BitOperations.TrailingZeroCount((uint)value);
    }
    public static int TrailingZeroCount(this uint value)
    {
        return BitOperations.TrailingZeroCount(value);
    }
    public static int TrailingZeroCount(this long value)
    {
        return BitOperations.TrailingZeroCount((ulong)value);
    }
    public static int TrailingZeroCount(this ulong value)
    {
        return BitOperations.TrailingZeroCount(value);
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

    public static int GapBits(this int value)
    {
        return GapBits((uint)value);
    }
    public static int GapBits(this uint value)
    {
        if (value is 0)
            return 0;

        const int bitCount = 32;
        int leading = value.LeadingZeroCount();
        int trailing = value.TrailingZeroCount();
        int popcount = value.PopCount();

        int width = bitCount - leading - trailing;
        int gaps = width - popcount;
        return gaps;
    }

    public static int GapBits(this long value)
    {
        return GapBits((ulong)value);
    }
    public static int GapBits(this ulong value)
    {
        if (value is 0)
            return 0;

        const int bitCount = 64;
        int leading = value.LeadingZeroCount();
        int trailing = value.TrailingZeroCount();
        int popcount = value.PopCount();

        int width = bitCount - leading - trailing;
        int gaps = width - popcount;
        return gaps;
    }
}
