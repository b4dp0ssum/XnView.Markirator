using XnView.Markirator.Core.UseCases.EvaluateTags.Entities;
using XnView.Markirator.Core.UseCases.EvaluateTags.Tools.Interfaces;
using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.UseCases.EvaluateTags.Tools;

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