using LinqToDB;
using LinqToDB.Data;
using XnView.Markirator.App.XnView.Entities;
using XnView.Markirator.App.XnView.Settings;

namespace XnView.Markirator.App.XnView.DataAccess;

internal class SQLiteConnection : DataConnection
{
    public ITable<XnViewTag> XnViewTags => this.GetTable<XnViewTag>();
    public ITable<XnViewImageTag> XnViewImageTags => this.GetTable<XnViewImageTag>();
    public ITable<XnViewFolder> XnViewFolders => this.GetTable<XnViewFolder>();
    public ITable<XnViewImage> XnViewImages => this.GetTable<XnViewImage>();

    // CTOR
    public SQLiteConnection(XnViewSettings appFilesLocator)
        : base(ProviderName.SQLite, appFilesLocator.ConnectionString)
    {
    }
}