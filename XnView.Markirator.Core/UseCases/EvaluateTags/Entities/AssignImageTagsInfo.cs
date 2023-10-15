using XnView.Markirator.Core.Common.Entities;
using XnView.Markirator.Core.UseCases.EvaluateTags.Tools;
using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.UseCases.EvaluateTags.Entities;

internal class AssignImageTagsInfo
{
    public ImageTagsInfo TaggedImageInfo { get; }

    public string XnViewFolderPath { get; }

    public XnViewFolder? XnViewFolder { get; set; }

    public XnViewImage? XnViewImage { get; set; }

    public XnViewTag[]? RequiredXnViewTags { get; set; }

    // CTOR
    private AssignImageTagsInfo(ImageTagsInfo taggedImageInfo, string xnViewFolderPath)
    {
        TaggedImageInfo = taggedImageInfo ?? throw new ArgumentNullException(nameof(taggedImageInfo));
        XnViewFolderPath = xnViewFolderPath ?? throw new ArgumentNullException(nameof(xnViewFolderPath));
    }

    public static AssignImageTagsInfo GetInstance(ImageTagsInfo taggedImageInfo, string imagesCatalogPath)
    {
        string? xnViewFolderPath = PathExtensions.GetXnViewFolderPath(taggedImageInfo.FilePath, imagesCatalogPath);

        if (xnViewFolderPath is null)
        {
            string errMsg =
                $"Failed to identify the file directory for XnView: {taggedImageInfo.FilePath}. " +
                $"Please make sure the directory has been indexed (just open it in XnView)";
            throw new ApplicationException(errMsg);
        }

        return new AssignImageTagsInfo(taggedImageInfo, xnViewFolderPath);
    }
}