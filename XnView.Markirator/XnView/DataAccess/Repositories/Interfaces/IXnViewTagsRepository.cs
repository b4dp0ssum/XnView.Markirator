using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;

internal interface IXnViewTagsRepository
{
    Task Create(XnViewTag newTag);
    Task InsertAll(IEnumerable<XnViewTag> newTags);
    Task<XnViewTag[]> Find(IEnumerable<string> labels, int parentId);
    Task<XnViewTag?> Find(string label, int parentId);
    Task<int> GetMaxGroupPosition(int parentId);
}