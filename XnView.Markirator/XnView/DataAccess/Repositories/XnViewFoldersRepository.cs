using LinqToDB;
using XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;
using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.DataAccess.Repositories;

internal class XnViewFoldersRepository : IXnViewFoldersRepository
{
    private readonly SQLiteConnection _db;

    // CTOR
    public XnViewFoldersRepository(SQLiteConnection db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public async Task<XnViewFolder[]> Find(IEnumerable<string> filePathList)
    {
        return await _db.XnViewFolders
            .Where(x => filePathList.Contains(x.FolderPath))
            .ToArrayAsync();
    }
}
