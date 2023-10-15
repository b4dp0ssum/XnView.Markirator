using XnView.Markirator.Core.UseCases.EvaluateTags.Entities;

namespace XnView.Markirator.Core.UseCases.EvaluateTags.Tools.Interfaces;

internal interface IXnViewImagesFiller
{
    void FillImages(IEnumerable<AssignImageTagsInfo> fileInfoArr);
}