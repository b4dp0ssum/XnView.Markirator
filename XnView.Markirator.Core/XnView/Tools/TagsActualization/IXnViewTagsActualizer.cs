using XnView.Markirator.Core.Common.Entities;
using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.XnView.Tools.TagsActualization;

/// <summary>
/// A tool for creating missing tags and making a complete list of needed tags 
/// (with loading existing tags from the database)
/// </summary>
internal interface IXnViewTagsActualizer
{
    XnViewTagsDictionary UpdateAndLoadTags(IEnumerable<ImageTagsInfo> fileInfoArr);
}