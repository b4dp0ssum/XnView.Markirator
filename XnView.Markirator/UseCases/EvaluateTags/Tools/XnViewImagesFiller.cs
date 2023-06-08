using LinqToDB;
using XnView.Markirator.App.Common.Tools.OutputWriting;
using XnView.Markirator.App.Common.UseCases;
using XnView.Markirator.App.UseCases.EvaluateTags.Entities;
using XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;
using XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;

namespace XnView.Markirator.App.UseCases.EvaluateTags.Tools;

internal class XnViewImagesFiller : IXnViewImagesFiller
{
    private readonly IOutputWriter _outputWriter;
    private readonly IXnViewImagesRepository _xnViewImagesRepository;

    // CTOR
    public XnViewImagesFiller(IOutputWriter outputWriter, IXnViewImagesRepository xnViewImagesRepository)
    {
        _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
        _xnViewImagesRepository = xnViewImagesRepository ?? throw new ArgumentNullException(nameof(xnViewImagesRepository));
    }

    public void FillImages(IEnumerable<AssignImageTagsInfo> fileInfoArr)
    {
        ActionsHandlingExtensions.HandleAction(
            _outputWriter,
            () => Action(fileInfoArr),
            "Fill XnView images info");
    }

    private void Action(IEnumerable<AssignImageTagsInfo> fileInfoArr)
    {
        int unprocessedImagesCounter = 0;

        var xnViewFolderIds = fileInfoArr.Select(x => x.XnViewFolder?.Id ?? 0).ToHashSet();

        // Find all the necessary records from the Images table in XnView
        var images = _xnViewImagesRepository.Find(xnViewFolderIds);

        var groupedXnViewImages = images
            .GroupBy(x => x.FolderId)
            .ToDictionary(x => x.Key, y => y.ToDictionary(image => image.FileName));

        foreach (var fileInfo in fileInfoArr)
        {
            if (fileInfo.XnViewFolder is null)
            {
                unprocessedImagesCounter++;
                continue;
            }

            int xnViewFolderId = fileInfo.XnViewFolder!.Id;
            string xnViewImagePath = fileInfo.TaggedImageInfo.GetImagePath();

            if (groupedXnViewImages[xnViewFolderId].ContainsKey(xnViewImagePath))
                fileInfo.XnViewImage = groupedXnViewImages[xnViewFolderId][xnViewImagePath];
            else
            {
                _outputWriter.Writeline($"WARNING: A file with an unindexed image is detected [{fileInfo.TaggedImageInfo.FilePath}]");
                unprocessedImagesCounter++;
            }
        }
    }
}