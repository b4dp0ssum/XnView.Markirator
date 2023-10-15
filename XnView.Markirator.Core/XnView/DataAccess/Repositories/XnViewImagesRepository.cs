using XnView.Markirator.Core.XnView.DataAccess.Repositories.Interfaces;
using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.XnView.DataAccess.Repositories;

internal class XnViewImagesRepository : IXnViewImagesRepository
{
    private readonly SQLiteConnection _db;

    // CTOR
    public XnViewImagesRepository(SQLiteConnection db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public XnViewImage[] Find(IEnumerable<int> xnViewFolderIds)
    {
        return _db.XnViewImages
            .Where(x => xnViewFolderIds.Contains(x.FolderId))
            .ToArray();
    }
}