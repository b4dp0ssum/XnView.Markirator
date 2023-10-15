using LinqToDB.Mapping;

namespace XnView.Markirator.Core.XnView.Entities;

[Table("Folders")]
internal class XnViewFolder
{
    [Column("FolderID")]
    public int Id { get; set; }

    [Column("Pathname")]
    public string FolderPath { get; set; } = string.Empty;
}
