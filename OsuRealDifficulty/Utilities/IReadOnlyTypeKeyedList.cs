namespace OsuRealDifficulty.Utilities;

public interface IReadOnlyTypeKeyedList<T>
    : IEnumerable<T>
    where T : notnull
{
    public IReadOnlyList<T> this[Type type] { get; }

    public IReadOnlyList<TA> OfType<TA>()
        where TA : class, T;

    public IEnumerable<TA> OfBaseType<TA>()
        where TA : class, T;
}
