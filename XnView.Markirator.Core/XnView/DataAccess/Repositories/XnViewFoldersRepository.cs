using XnView.Markirator.Core.XnView.DataAccess.Repositories.Interfaces;
using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.XnView.DataAccess.Repositories;

internal class XnViewFoldersRepository : IXnViewFoldersRepository
{
    private readonly SQLiteConnection _db;

    // CTOR
    public XnViewFoldersRepository(SQLiteConnection db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public XnViewFolder[] Find(IEnumerable<string> filePathList)
    {
        return _db.XnViewFolders
            .Where(x => filePathList.Contains(x.FolderPath))
            .ToArray();
    }
}
