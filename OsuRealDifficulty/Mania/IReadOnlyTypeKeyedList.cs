namespace OsuRealDifficulty.Mania;

public interface IReadOnlyTypeKeyedList<T>
    : IEnumerable<T>
    where T : notnull
{
    public IReadOnlyList<T> this[Type type] { get; }

    public IReadOnlyList<TA> OfType<TA>()
        where TA : T;

    public IEnumerable<TA> OfBaseType<TA>()
        where TA : T;
}
