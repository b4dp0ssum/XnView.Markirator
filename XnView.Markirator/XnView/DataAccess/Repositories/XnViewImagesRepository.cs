using LinqToDB;
using XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;
using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.DataAccess.Repositories;

internal class XnViewImagesRepository : IXnViewImagesRepository
{
    private readonly SQLiteConnection _db;

    // CTOR
    public XnViewImagesRepository(SQLiteConnection db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public async Task<XnViewImage[]> Find(IEnumerable<int> xnViewFolderIds)
    {
        return await _db.XnViewImages
            .Where(x => xnViewFolderIds.Contains(x.FolderId))
            .ToArrayAsync();
    }
}