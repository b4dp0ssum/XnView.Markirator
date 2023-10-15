namespace XnView.Markirator.Core.Common.Entities;

internal class ImageTagsInfo
{
    public string FilePath { get; set; } = string.Empty;

    public List<string> Tags { get; set; } = new List<string>();

    // CTOR -- for DESERIALIZE
    public ImageTagsInfo()
    {
    }

    // CTOR
    public ImageTagsInfo(string filePath)
    {
        FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }
}