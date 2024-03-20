using System.Reflection;

namespace OsuRealDifficulty.UI.WinForms;

using Getter = Func<object?, object?>;
using Setter = Action<object?, object?>;

public sealed record MemberTargetBinding(MemberInfo MemberInfo, object? Target)
{
    private readonly Getter? _getMethod
        = MemberInfo.CreateGetMethodForPropertyOrField();

    private readonly Setter? _setMethod
        = MemberInfo.CreateSetMethodForPropertyOrField();

    public object? GetValue()
    {
        return _getMethod!.Invoke(Target);
    }

    public void SetValue(object? value)
    {
        _setMethod!.Invoke(Target, value);
    }
}
