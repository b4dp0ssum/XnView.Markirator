using XnView.Markirator.App.Common.Entities;
using XnView.Markirator.App.UseCases.EvaluateTags.Tools;
using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.UseCases.EvaluateTags.Entities;

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

        return xnViewFolderPath == null
            ? throw new ArgumentException("Не удалось определить директорию файла для XnView")
            : new AssignImageTagsInfo(taggedImageInfo, xnViewFolderPath);
    }
}