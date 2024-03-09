using Garyon.DataStructures;
using Garyon.Extensions;
using Garyon.Reflection;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace OsuRealDifficulty.Utilities;

public sealed class TypeKeyedList<T>
    : IReadOnlyTypeKeyedList<T>
    where T : notnull
{
    private readonly FlexibleInitializableValueDictionary<Type, List<T>>
        _dictionary = new();

    public void AddRange(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public void Add(T value)
    {
        var type = value.GetType();
        _dictionary[type].Add(value);
    }

    public IList<TA> OfType<TA>()
        where TA : T
    {
        return this[typeof(TA)] as IList<TA>
            ?? [];
    }

    public IEnumerable<TA> OfBaseType<TA>()
        where TA : T
    {
        var queriedType = typeof(TA);
        var result = Enumerable.Empty<TA>();
        foreach (var (type, values) in _dictionary)
        {
            if (type.InheritsOrEquals(queriedType))
            {
                var upcast = values as IEnumerable<TA>;
                result = result.Concat(upcast!);
            }
        }

        return result;
    }

    public bool ContainsKey(Type key)
    {
        return _dictionary.ContainsKey(key);
    }

    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out IEnumerable<T> value)
    {
        bool result = _dictionary.TryGetValue(key, out var t);
        value = t;
        return result;
    }

    public IList<T> this[Type type]
    {
        get
        {
            return _dictionary.ValueOrDefault(type) ?? [];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _dictionary.Values.Flatten().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    IReadOnlyList<T> IReadOnlyTypeKeyedList<T>.this[Type type]
    {
        get
        {
            return this[type] as IReadOnlyList<T>
                ?? [];
        }
    }

    IReadOnlyList<TA> IReadOnlyTypeKeyedList<T>.OfType<TA>()
    {
        return OfType<TA>() as IReadOnlyList<TA>
            ?? [];
    }
}
