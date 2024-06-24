using System.Text;

namespace OsuFileTools.Core;

public ref struct SpanLineEnumeratorObserver
{
    private bool _isActive;

    public readonly bool IsActive => _isActive;

    public bool MoveNext(ref SpanLineEnumerator enumerator)
    {
        _isActive = enumerator.MoveNext();
        return _isActive;
    }
}
