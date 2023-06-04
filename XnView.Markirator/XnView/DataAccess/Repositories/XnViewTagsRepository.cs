using LinqToDB;
using LinqToDB.Data;
using XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;
using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.DataAccess.Repositories;

internal class XnViewTagsRepository : IXnViewTagsRepository
{
    private readonly SQLiteConnection _db;

    public XnViewTagsRepository(SQLiteConnection db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public async Task<XnViewTag?> Find(string label, int parentId)
    {
        return await _db.XnViewTags
            .Where(x => x.ParentId == parentId)
            .Where(x => x.Label == label)
            .FirstOrDefaultAsync();
    }

    public async Task<XnViewTag[]> Find(IEnumerable<string> labels, int parentId)
    {
        return await _db.XnViewTags
            .Where(x => x.ParentId == parentId)
            .Where(x => labels.Contains(x.Label ?? string.Empty))
            .ToArrayAsync();
    }

    public async Task<int> GetMaxGroupPosition(int parentId)
    {
        int? maxi = await _db.XnViewTags
            .Where(x => x.ParentId == parentId)
            .Select(x => (int?)x.TagGroupId)
            .MaxAsync();

        return maxi ?? 0;
    }

    public async Task Create(XnViewTag newTag)
    {
        newTag.Id = await _db.InsertWithInt32IdentityAsync(newTag);
    }

    public async Task InsertAll(IEnumerable<XnViewTag> newTags)
    {
        await _db.BulkCopyAsync(newTags);
    }
}