using XnView.Markirator.App.UseCases.EvaluateTags.Entities;

namespace XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;

internal interface IXnViewImagesFiller
{
    Task FillImages(IEnumerable<AssignImageTagsInfo> fileInfoArr);
}