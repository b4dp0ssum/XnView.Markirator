using Microsoft.Extensions.Configuration;

namespace XnView.Markirator.Core.XnView.Settings;

internal class XnViewSettings : IXnViewSettings
{
    private readonly IConfigurationRoot _config;

    private static string DbName => "XnView.db";

    public virtual string DbFolder 
    { 
        get => DbFolderSection.Value!; 
        set => DbFolderSection.Value = value; 
    }

    public string DbPath => Path.Combine(DbFolder, DbName);

    public string ConnectionString => $"Data Source={DbPath};";

    public string ImagesCatalogPath
    {
        get => ImagesCatalogPathSection.Value!;
        set => ImagesCatalogPathSection.Value = value;
    }

    // CTOR
    public XnViewSettings(IConfigurationRoot config)
    {
        _config = config;
    }

    private IConfigurationSection DbFolderSection => _config
        .GetSection(nameof(XnViewSettings))!
        .GetSection(nameof(DbFolder));

    private IConfigurationSection ImagesCatalogPathSection => _config
        .GetSection(nameof(XnViewSettings))!
        .GetSection(nameof(ImagesCatalogPath));
}