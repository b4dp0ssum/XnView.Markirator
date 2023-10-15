namespace XnView.Markirator.Core.XnView.Settings;

internal interface IXnViewSettings
{
    string ConnectionString { get; }
    string DbFolder { get; set; }
    string DbPath { get; }
    string ImagesCatalogPath { get; set; }
}