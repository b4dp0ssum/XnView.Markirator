using LinqToDB;
using LinqToDB.Data;
using XnView.Markirator.Core.XnView.Entities;
using XnView.Markirator.Core.XnView.Settings;

namespace XnView.Markirator.Core.XnView.DataAccess;

internal class SQLiteConnection : DataConnection
{
    public ITable<XnViewTag> XnViewTags => this.GetTable<XnViewTag>();
    public ITable<XnViewImageTag> XnViewImageTags => this.GetTable<XnViewImageTag>();
    public ITable<XnViewFolder> XnViewFolders => this.GetTable<XnViewFolder>();
    public ITable<XnViewImage> XnViewImages => this.GetTable<XnViewImage>();

    // CTOR
    public SQLiteConnection(IXnViewSettings appFilesLocator)
        : base(ProviderName.SQLite, appFilesLocator.ConnectionString)
    {
    }
}