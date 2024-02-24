namespace XnView.Markirator.UI.Tools.Extensions;

internal static class FilesExtensions
{
    public static bool IsDirectory(string path)
    {
        return Directory.Exists(path);
    }

    public static string[] GetSubFolders(string rootPath)
    {
        return Directory.GetDirectories(rootPath);
    }

    public static string[] GetAllJsonFilesInFolder(string folderPath)
    {
        if (Directory.Exists(folderPath))
        {
            return Directory.GetFiles(folderPath, "*.json");
        }
        else
        {
            throw new DirectoryNotFoundException($"The directory {folderPath} does not exist");
        }
    }

    public static bool DirectoryContainsImages(string dirPath)
    {
        var imageExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

        try
        {
            // Get all files in the directory
            var files = Directory.GetFiles(dirPath);

            // Check each file to see if it has one of the image extensions
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file).ToLower();
                if (imageExtensions.Contains(extension))
                {
                    return true;
                }
            }

            // If no image files were found, return false
            return false;
        }
        catch (DirectoryNotFoundException)
        {
            // Handle the case where the directory doesn't exist
            throw new DirectoryNotFoundException("Directory not found: " + dirPath);
        }
    }
}