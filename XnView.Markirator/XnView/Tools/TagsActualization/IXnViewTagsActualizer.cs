using XnView.Markirator.App.Common.Entities;
using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.Tools.TagsActualization;

/// <summary>
/// A tool for creating missing tags and making a complete list of needed tags 
/// (with loading existing tags from the database)
/// </summary>
internal interface IXnViewTagsActualizer
{
    XnViewTagsDictionary UpdateAndLoadTags(IEnumerable<ImageTagsInfo> fileInfoArr);
}