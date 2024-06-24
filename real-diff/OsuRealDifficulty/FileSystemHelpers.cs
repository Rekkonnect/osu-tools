namespace OsuRealDifficulty;

public static class FileSystemHelpers
{
    public static DirectoryInfo Subdirectory(this DirectoryInfo directory, string subdirectoryName)
    {
        var finalName = Path.Combine(directory.FullName, subdirectoryName);
        return new(finalName);
    }

    public static DirectoryInfo Subdirectory(this DirectoryInfo directory, DirectoryInfo subdirectory)
    {
        var finalName = Path.Combine(directory.FullName, subdirectory.FullName);
        return new(finalName);
    }

    public static FileInfo File(
        this DirectoryInfo directory,
        string fileName)
    {
        var finalName = Path.Combine(directory.FullName, fileName);
        return new(finalName);
    }

    public static FileInfo File(
        this DirectoryInfo directory,
        FileInfo fileName)
    {
        var finalName = Path.Combine(directory.FullName, fileName.FullName);
        return new(finalName);
    }

    public static FileInfo FileWithExtension(
        this DirectoryInfo directory,
        string fileName,
        string extension)
    {
        var fullFileName = FileNameWithExtension(fileName, extension);
        return directory.File(fullFileName);
    }

    public static string FileNameWithExtension(string name, string? extension)
    {
        if (string.IsNullOrEmpty(extension))
            return name;

        return $"{name}.{extension}";
    }
}
