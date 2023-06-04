using XnView.Markirator.App.UseCases.EvaluateTags.Entities;

namespace XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;

internal interface IXnViewFoldersFiller
{
    Task FillFolders(IEnumerable<AssignImageTagsInfo> fileInfoArr);
}