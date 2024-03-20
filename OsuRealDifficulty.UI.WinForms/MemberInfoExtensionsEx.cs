using System.Reflection;

namespace OsuRealDifficulty.UI.WinForms;

using Getter = Func<object?, object?>;
using Setter = Action<object?, object?>;

public static class MemberInfoExtensionsEx
{
    public static void SetFieldOrPropertyValue(this MemberInfo member, object? target, object? value)
    {
        if (member is PropertyInfo property)
        {
            property.SetValue(target, value);
        }
        else if (member is FieldInfo field)
        {
            field.SetValue(target, value);
        }
    }

    public static Getter? CreateGetMethodForPropertyOrField(this MemberInfo member)
    {
        if (member is PropertyInfo property)
        {
            return property.GetMethod?.CreateDelegate<Getter>();
        }
        else if (member is FieldInfo field)
        {
            return field.GetValue;
        }

        return null;
    }

    public static Setter? CreateSetMethodForPropertyOrField(this MemberInfo member)
    {
        if (member is PropertyInfo property)
        {
            return property.SetMethod?.CreateDelegate<Setter>();
        }
        else if (member is FieldInfo field)
        {
            return field.SetValue;
        }

        return null;
    }
}
