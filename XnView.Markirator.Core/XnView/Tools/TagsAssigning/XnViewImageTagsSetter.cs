using LinqToDB;
using LinqToDB.Data;
using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.UseCases;
using XnView.Markirator.Core.UseCases.EvaluateTags.Entities;
using XnView.Markirator.Core.XnView.DataAccess;
using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.XnView.Tools.TagsAssigning;

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

            int imageId = fileInfo.XnViewImage!.Id;
            HashSet<int> existedTags;
            if (existedTagsDict.ContainsKey(imageId))
            {
                existedTags = existedTagsDict[imageId];
            }
            else
            {
                existedTags = new HashSet<int>();
                existedTagsDict.Add(imageId, existedTags);
            }

            var tagLinksToCreate = fileInfo
                .RequiredXnViewTags!
                .Where(x => !existedTags.Contains(x.Id))
                .Select(x => BuildImageTagLink(fileInfo, x))
                .ToArray();

            allTagLinksToCreate.AddRange(tagLinksToCreate);
            AddToExistedTags(existedTags, tagLinksToCreate);
        }

        _db.BulkCopy(allTagLinksToCreate);

        _outputWriter.WriteLine(0, $"Number of unprocessed images: {unprocessedImagesCounter}");
        _outputWriter.WriteLine(0, $"Total categories assigned: {allTagLinksToCreate.Count}");
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

    private static void AddToExistedTags(
        HashSet<int> existedTags,
        XnViewImageTag[] xnViewImageTags)
    {
        var tagIds = xnViewImageTags.Select(x => x.TagId).ToArray();
        foreach (var tagId in tagIds)
        {
            existedTags.Add(tagId);
        }
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