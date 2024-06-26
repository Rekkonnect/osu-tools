﻿using System.Diagnostics.CodeAnalysis;
using System.Drawing.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using OsuRealDifficulty.UI.WinForms.Utilities;

namespace OsuRealDifficulty.UI.WinForms;

internal sealed partial class ThemeFonts
{
    public const string MainFontName = "Aptos Display";
    public const float MainFontSize = 10;
    public const FontStyle MainFontStyle = FontStyle.Regular;

    public static ThemeFonts Instance { get; } = new();

    public PrivateFontCollection Fonts { get; private set; }
    public Font? MainFont { get; private set; }
    public FontFamily? MainFontFamily { get; private set; }

    private ThemeFonts()
    {
        LoadFontsFromResources();
    }

    [MemberNotNull(nameof(Fonts))]
    private void LoadFontsFromResources()
    {
        var fonts = new PrivateFontCollection();
        var culture = FontResources.Culture ?? CultureInfo.CurrentUICulture;
        var resources = FontResources.ResourceManager
            .EnumerateResources(culture);

        foreach (var resource in resources)
        {
            AddResourceFont(resource.Value!, fonts);
        }

        Fonts = fonts;
        MainFont = GetMainFont();
    }

    private Font? GetMainFont()
    {
        MainFontFamily = GetDefaultFontFamily();
        if (MainFontFamily is null)
        {
            return null;
        }

        return new Font(MainFontFamily, MainFontSize, MainFontStyle);
    }

    private FontFamily? GetDefaultFontFamily()
    {
        var mainFamily = Fonts.Families
            .FirstOrDefault(s => s.Name is MainFontName);
        if (mainFamily is not null)
            return mainFamily;

        return Fonts.Families.FirstOrDefault();
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
            uint addedFonts = 0;
            nint resultHandle = AddFontMemResourceEx(
                (nint)resourceBytesPtr,
                (uint)resourceBytes.Length,
                0,
                ref addedFonts);

            // We check whether this was a valid font that we imported
            // Unfortunately, we cannot conveniently map the incoming resource
            // to its original declaration from the source/manifest
            if (addedFonts > 0)
            {
                fonts.AddMemoryFont((nint)resourceBytesPtr, resourceBytes.Length);
            }
        }
    }

    // "Documentation":
    // https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontmemresourceex?redirectedfrom=MSDN
    [LibraryImport("gdi32.dll")]
    private static partial IntPtr AddFontMemResourceEx(
        IntPtr pbFont,
        uint cbFont,
        IntPtr pdv,
        ref uint pcFonts);
}
