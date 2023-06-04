using XnView.Markirator.App.UseCases.EvaluateTags.Entities;
using XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;
using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.UseCases.EvaluateTags.Tools;

internal class RequiredXnViewTagsFiller : IRequiredXnViewTagsFiller
{
    public void FillRequiredXnViewTags(IEnumerable<AssignImageTagsInfo> fileInfoArr, XnViewTagsDictionary tagsDict)
    {
        foreach (var fileInfo in fileInfoArr)
        {
            var tags = tagsDict.TryGetAll(fileInfo.TaggedImageInfo.Tags);
            fileInfo.RequiredXnViewTags = tags;
        }
    }
}