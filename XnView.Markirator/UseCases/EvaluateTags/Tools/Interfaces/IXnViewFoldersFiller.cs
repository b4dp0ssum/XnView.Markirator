using XnView.Markirator.App.UseCases.EvaluateTags.Entities;

namespace XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;

internal interface IXnViewFoldersFiller
{
    void FillFolders(IEnumerable<AssignImageTagsInfo> fileInfoArr);
}