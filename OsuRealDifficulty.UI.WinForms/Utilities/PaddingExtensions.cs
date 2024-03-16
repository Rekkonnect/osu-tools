namespace OsuRealDifficulty.UI.WinForms.Utilities;

public static class PaddingExtensions
{
    public static Padding WithHorizontal(this Padding padding, int horizontal)
    {
        var top = padding.Top;
        var bottom = padding.Bottom;
        return new(horizontal, top, horizontal, bottom);
    }
    public static Padding WithVertical(this Padding padding, int vertical)
    {
        var left = padding.Left;
        var right = padding.Right;
        return new(left, vertical, right, vertical);
    }
}
