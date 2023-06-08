using XnView.Markirator.App.UseCases.EvaluateTags.Entities;

namespace XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;

internal interface IXnViewImagesFiller
{
    void FillImages(IEnumerable<AssignImageTagsInfo> fileInfoArr);
}