namespace XnView.Markirator.App.XnView.Settings;

internal class XnViewSettings
{
    private static string DbName => "XnView.db";

    public virtual string DbFolder { get; }

    public string DbPath => Path.Combine(DbFolder, DbName);

    public string ConnectionString => $"Data Source={DbPath};";

    public string ImagesCatalogPath { get; set; }

    // CTOR
    public XnViewSettings(string dbFolder, string imagesCatalogPath)
    {
        DbFolder = dbFolder;
        ImagesCatalogPath = imagesCatalogPath;
    }
}