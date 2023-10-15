using XnView.Markirator.Core.UseCases.EvaluateTags.Entities;

namespace XnView.Markirator.Core.UseCases.EvaluateTags.Tools.Interfaces;

internal interface IXnViewFoldersFiller
{
    void FillFolders(IReadOnlyList<AssignImageTagsInfo> fileInfoArr);
}