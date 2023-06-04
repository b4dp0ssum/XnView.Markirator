using XnView.Markirator.App.UseCases.EvaluateTags.Entities;
using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;

internal interface IRequiredXnViewTagsFiller
{
    void FillRequiredXnViewTags(IEnumerable<AssignImageTagsInfo> fileInfoArr, XnViewTagsDictionary tagsDict);
}