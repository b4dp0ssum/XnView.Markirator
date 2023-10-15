using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.XnView.DataAccess.Repositories.Interfaces;

internal interface IXnViewTagsRepository
{
    void Create(XnViewTag newTag);
    void InsertAll(IEnumerable<XnViewTag> newTags);
    XnViewTag[] Find(IEnumerable<string> labels, int parentId);
    XnViewTag? Find(string label, int parentId);
    int GetMaxGroupPosition(int parentId);
}