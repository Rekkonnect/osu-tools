using System.Reflection;

namespace OsuRealDifficulty.UI.WinForms;

public static class ApplicationMetadata
{
    public const string Name = "osu!mania difficulty analyzer";

#if ENABLE_GIT_INFO
    public static GitInformation GitInfo
        => GitInformation.GetAssemblyInstance(typeof(ApplicationMetadata));

    static ApplicationMetadata()
    {
        GitInformation.ApplyAssemblyAttributes(ThisAssembly);
    }
#endif

    public static Assembly ThisAssembly => typeof(ApplicationMetadata).Assembly;

    public static string? CurrentVersion => ThisAssembly
        .GetCustomAttribute<AssemblyFileVersionAttribute>()
        ?.Version;

#if ENABLE_GIT_INFO
    public static string VersionString => $"v{CurrentVersion}-{GitInfo.Commit}";
#else
    public static string VersionString => $"v{CurrentVersion}";
#endif

    public static string FullTitle => $"{Name} [{VersionString}]";
}
