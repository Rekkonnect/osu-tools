using System.Text;

namespace OsuFileTools.Core;

public ref struct SpanLineEnumeratorWrapper(SpanLineEnumerator enumerator)
{
    private SpanLineEnumerator _enumerator = enumerator;

    private bool _isActive;

    public readonly ReadOnlySpan<char> Current => _enumerator.Current;

    public readonly bool IsActive => _isActive;

    public bool MoveNext()
    {
        _isActive = _enumerator.MoveNext();
        return _isActive;
    }
}
