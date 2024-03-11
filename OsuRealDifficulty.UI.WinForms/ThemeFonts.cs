using System.Drawing.Text;
using System.Globalization;

namespace OsuRealDifficulty.UI.WinForms;

internal sealed class ThemeFonts
{
    public const string MainFontName = "Aptos";
    public const int MainFontSize = 10;
    public const FontStyle MainFontStyle = FontStyle.Regular;

    public static ThemeFonts Instance { get; } = new();

    private readonly Lazy<PrivateFontCollection> _fonts
        = new(LoadFontsFromResources);

    public PrivateFontCollection Fonts => _fonts.Value;

    private ThemeFonts()
    {
    }

    private static PrivateFontCollection LoadFontsFromResources()
    {
        var fonts = new PrivateFontCollection();
        var culture = FontResources.Culture ?? CultureInfo.CurrentUICulture;
        var resources = FontResources.ResourceManager
            .EnumerateResources(culture);

        foreach (var resource in resources)
        {
            AddResourceFont(resource.Value!, fonts);
        }

        return fonts;
    }

    private static unsafe void AddResourceFont(object resource, PrivateFontCollection fonts)
    {
        // black magic fuckery copied from
        // https://stackoverflow.com/questions/556147/how-do-i-embed-my-own-fonts-in-a-winforms-app

        if (resource is not byte[] resourceBytes)
        {
            // We have a resource that is not a byte[] -- better throw something?
            return;
        }

        fixed (byte* resourceBytesPtr = resourceBytes)
        {
            fonts.AddMemoryFont((nint)resourceBytesPtr, resourceBytes.Length);
        }
    }
}
