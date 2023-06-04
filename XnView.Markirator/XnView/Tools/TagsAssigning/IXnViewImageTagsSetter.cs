using XnView.Markirator.App.UseCases.EvaluateTags.Entities;

namespace XnView.Markirator.App.XnView.Tools.TagsAssigning;

/// <summary>
/// Tool for assigning tags to selected images
/// </summary>
internal interface IXnViewImageTagsSetter
{
    Task SetTags(IEnumerable<AssignImageTagsInfo> fileInfoArr);
}