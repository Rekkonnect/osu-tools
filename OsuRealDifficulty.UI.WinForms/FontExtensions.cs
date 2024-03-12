namespace OsuRealDifficulty.UI.WinForms;

public static class FontExtensions
{
    public static Font WithFamily(this Font font, FontFamily family)
    {
        return new(family, font.Size, font.Style, font.Unit);
    }
    public static Font WithSize(this Font font, float size)
    {
        return new(font.FontFamily, size, font.Style, font.Unit);
    }
    public static Font WithStyle(this Font font, FontStyle style)
    {
        return new(font.FontFamily, font.Size, style, font.Unit);
    }
}
