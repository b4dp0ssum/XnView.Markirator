using XnView.Markirator.Core.UseCases.EvaluateTags.Entities;
using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.UseCases.EvaluateTags.Tools.Interfaces;

internal interface IRequiredXnViewTagsFiller
{
    void FillRequiredXnViewTags(IEnumerable<AssignImageTagsInfo> fileInfoArr, XnViewTagsDictionary tagsDict);
}