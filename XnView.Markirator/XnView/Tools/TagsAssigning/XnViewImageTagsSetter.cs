using LinqToDB;
using LinqToDB.Data;
using XnView.Markirator.App.Common.Tools.OutputWriting;
using XnView.Markirator.App.Common.UseCases;
using XnView.Markirator.App.UseCases.EvaluateTags.Entities;
using XnView.Markirator.App.XnView.DataAccess;
using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.Tools.TagsAssigning;

internal class XnViewImageTagsSetter : IXnViewImageTagsSetter
{
    private readonly IOutputWriter _outputWriter;
    private readonly SQLiteConnection _db;

    // CTOR
    public XnViewImageTagsSetter(IOutputWriter outputWriter, SQLiteConnection db)
    {
        _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public void SetTags(IEnumerable<AssignImageTagsInfo> fileInfoArr)
    {
        ActionsHandlingExtensions.HandleAction(
            _outputWriter,
            () => Action(fileInfoArr),
            "Assignment of categories");
    }

    private void Action(IEnumerable<AssignImageTagsInfo> fileInfoArr)
    {
        int unprocessedImagesCounter = 0;

        var allTagLinksToCreate = new List<XnViewImageTag>();
        var existedTagsDict = BuildExistedTagsDictionary(fileInfoArr);

        foreach (var fileInfo in fileInfoArr)
        {
            if (fileInfo.XnViewImage is null)
            {
                unprocessedImagesCounter++;
                continue;
            }

            var existedTags = existedTagsDict.TryGetValue(fileInfo.XnViewImage!.Id, out var x)
                ? x : new HashSet<int>();

            var tagLinksToCreate = fileInfo
                .RequiredXnViewTags!
                .Where(x => !existedTags.Contains(x.Id))
                .Select(x => BuildImageTagLink(fileInfo, x))
                .ToArray();

            allTagLinksToCreate.AddRange(tagLinksToCreate);
        }

        _db.BulkCopy(allTagLinksToCreate);

        _outputWriter.Writeline($"Number of unprocessed images: {unprocessedImagesCounter}");
        _outputWriter.Writeline($"Total categories assigned: {allTagLinksToCreate.Count}");
    }

    private Dictionary<int, HashSet<int>> BuildExistedTagsDictionary(IEnumerable<AssignImageTagsInfo> fileInfoArr)
    {
        var xnViewimageIds = fileInfoArr
            .Where(x => x.XnViewImage is not null)
            .Select(x => x.XnViewImage!.Id)
            .ToHashSet();

        var xnViewImageTagLinks = _db.XnViewImageTags
            .Where(x => xnViewimageIds.Contains(x.ImageId))
            .ToArray();

        return xnViewImageTagLinks
            .GroupBy(x => x.ImageId)
            .ToDictionary(x => x.Key, y => y.Select(link => link.TagId).ToHashSet());
    }

    private static XnViewImageTag BuildImageTagLink(AssignImageTagsInfo fileInfo, XnViewTag tag)
    {
        return new XnViewImageTag()
        {
            ImageId = fileInfo.XnViewImage!.Id,
            TagId = tag.Id,
        };
    }
}