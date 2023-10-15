using XnView.Markirator.Core.UseCases.EvaluateTags.Entities;

namespace XnView.Markirator.Core.XnView.Tools.TagsAssigning;

/// <summary>
/// Tool for assigning tags to selected images
/// </summary>
internal interface IXnViewImageTagsSetter
{
    void SetTags(IEnumerable<AssignImageTagsInfo> fileInfoArr);
}