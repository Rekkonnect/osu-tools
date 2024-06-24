using System.Linq.Expressions;
using System.Reflection;

namespace OsuRealDifficulty.UI.WinForms;

public static class BindingExtensions
{
    // CheckBox
    public static void BindTo(this CheckBox checkBox, Expression<Func<bool>> expression)
    {
        var member = expression.Body;
        if (member is not MemberExpression parentMember)
            return;

        var memberInfo = parentMember.Member;
        // TODO
        object? target = null;
        BindTo(checkBox, memberInfo, target);
    }

    public static void BindTo(this CheckBox checkBox, MemberInfo property, object? target)
    {
        var binding = new MemberTargetBinding(property, target);

        var currentValue = (bool)binding.GetValue()!;
        checkBox.Checked = currentValue;

        checkBox.CheckedChanged += SetChecked;

        void SetChecked(object? sender, EventArgs e)
        {
            binding.SetValue(checkBox.Checked);
        }
    }

    // TextBox
    public static void BindTo(this TextBox textBox, Expression<Func<string?>> expression)
    {
        var member = expression.Body;
        if (member is not MemberExpression parentMember)
            return;

        var memberInfo = parentMember.Member;
        // TODO
        object? target = null;
        BindTo(textBox, memberInfo, target);
    }

    public static void BindTo(this TextBox textBox, MemberInfo property, object? target)
    {
        var binding = new MemberTargetBinding(property, target);

        var currentValue = (string?)binding.GetValue()!;
        textBox.Text = currentValue;

        textBox.TextChanged += SetText;

        void SetText(object? sender, EventArgs e)
        {
            binding.SetValue(textBox.Text);
        }
    }
}
