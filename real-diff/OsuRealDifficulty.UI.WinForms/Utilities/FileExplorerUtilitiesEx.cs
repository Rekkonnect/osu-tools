using Garyon.Functions.Windows;

namespace OsuRealDifficulty.UI.WinForms.Utilities;

public static class FileExplorerUtilitiesEx
{
    public static void StartExplorerAtRoot(DirectoryInfo directory)
    {
        FileExplorerUtilities.StartExplorerAtRoot(directory.FullName);
    }

    public static void StartExplorerAtRelativeRoot(string relativePath)
    {
        var directory = new DirectoryInfo(relativePath);
        StartExplorerAtRoot(directory);
    }
}
