using XnView.Markirator.Core.Common.Entities;

namespace XnView.Markirator.Core.UseCases.EvaluateTags.Tools;

internal static class PathExtensions
{
    public static char DeepbooruPathSeparator = '\\';

    public static char XnViewPathSeparator = '/';

    public const string EvaluatedTagsFolderName = "EvaluatedTags";

    public static string PrepareDeepbooruPath(string filePath)
    {
        return filePath.Replace(DeepbooruPathSeparator, XnViewPathSeparator);
    }

    public static string BuildImagePath(string imagesCatalogPath, string folder, string fileName)
    {
        if (folder.FirstOrDefault() == '@')
        {
            folder = folder.TrimStart('@');
            folder = Path.Combine(imagesCatalogPath, folder);
        }

        return Path.Combine(folder, fileName);
    }

    public static string GetImagePath(this ImageTagsInfo fileInfo)
    {
        return Path.GetFileName(fileInfo.FilePath);
    }

    public static string? GetXnViewFolderPath(string filePath, string imagesCatalogPath)
    {
        string? folder = Path.GetDirectoryName(filePath);

        if (folder?.StartsWith(imagesCatalogPath) == true)
        {
            folder = folder[imagesCatalogPath.Length..];
            folder = folder.Replace(DeepbooruPathSeparator, XnViewPathSeparator);
            folder = folder.TrimStart(XnViewPathSeparator);

            if (!folder.EndsWith(XnViewPathSeparator))
                folder += XnViewPathSeparator;

            return $"@{folder}";
        }

        return null;
    }

    public static string GetEvaluatedTagsFolderPath()
        => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EvaluatedTags");
}