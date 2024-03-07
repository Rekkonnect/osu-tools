using Garyon.Extensions;
using Garyon.Extensions.ArrayExtensions;
using Garyon.Objects;
using System.Diagnostics.CodeAnalysis;

namespace OsuRealDifficulty.Mania;

// Data structures are very important in any project

public sealed class OrderedMapList<TKey, TValue>(int capacity)
     where TKey : notnull, IComparable<TKey>
{
    private readonly KeyValuePair<TKey, TValue>[] _map
        = new KeyValuePair<TKey, TValue>[capacity];

    private int _currentIndex = 0;

    public void AddNext(TKey key, TValue value)
    {
        _map[_currentIndex] = new(key, value);
        _currentIndex++;
    }

    public void Clear()
    {
        _map.Clear();
        _currentIndex = 0;
    }

    public bool TryGetValue(TKey key, [NotNullWhen(true)] out TValue? value)
    {
        value = default;
        int index = BinarySearch(key);
        if (index < 0)
            return false;

        value = _map[index].Value!;
        return true;
    }

    public TValue this[TKey key]
    {
        get
        {
            bool found = TryGetValue(key, out var value);
            if (!found)
                throw new KeyNotFoundException(key.ToString());

            return value!;
        }
        set
        {
            int index = BinarySearch(key);
            if (index < 0)
                return;

            ref var entry = ref _map[index];
            entry = entry.WithValue<TKey, TValue>(value);
        }
    }

    private int BinarySearch(TKey key)
    {
        int min = 0;
        int max = _map.Length - 1;
        while (min <= max)
        {
            int mid = (min + max) >> 1;
            var midKey = _map[mid].Key;
            var comparison = midKey.GetComparisonResult(key);
            switch (comparison)
            {
                case ComparisonResult.Equal:
                    return mid;

                case ComparisonResult.Less:
                    min = mid + 1;
                    continue;

                case ComparisonResult.Greater:
                    max = mid - 1;
                    continue;
            }
        }

        return -1;
    }
}
