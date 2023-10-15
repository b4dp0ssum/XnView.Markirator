using LinqToDB;
using LinqToDB.Data;
using XnView.Markirator.Core.XnView.DataAccess.Repositories.Interfaces;
using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.XnView.DataAccess.Repositories;

internal class XnViewTagsRepository : IXnViewTagsRepository
{
    private readonly SQLiteConnection _db;

    public XnViewTagsRepository(SQLiteConnection db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public XnViewTag? Find(string label, int parentId)
    {
        return _db.XnViewTags
            .Where(x => x.ParentId == parentId)
            .Where(x => x.Label == label)
            .FirstOrDefault();
    }

    public XnViewTag[] Find(IEnumerable<string> labels, int parentId)
    {
        return _db.XnViewTags
            .Where(x => x.ParentId == parentId)
            .Where(x => labels.Contains(x.Label ?? string.Empty))
            .ToArray();
    }

    public int GetMaxGroupPosition(int parentId)
    {
        int? maxi = _db.XnViewTags
            .Where(x => x.ParentId == parentId)
            .Select(x => (int?)x.TagGroupId)
            .Max();

        return maxi ?? 0;
    }

    public void Create(XnViewTag newTag)
    {
        newTag.Id = _db.InsertWithInt32Identity(newTag);
    }

    public void InsertAll(IEnumerable<XnViewTag> newTags)
    {
        _db.BulkCopy(newTags);
    }
}