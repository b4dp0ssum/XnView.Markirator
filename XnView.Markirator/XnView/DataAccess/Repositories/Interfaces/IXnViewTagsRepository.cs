using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;

internal interface IXnViewTagsRepository
{
    void Create(XnViewTag newTag);
    void InsertAll(IEnumerable<XnViewTag> newTags);
    XnViewTag[] Find(IEnumerable<string> labels, int parentId);
    XnViewTag? Find(string label, int parentId);
    int GetMaxGroupPosition(int parentId);
}