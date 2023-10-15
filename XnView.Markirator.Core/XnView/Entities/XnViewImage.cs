using LinqToDB.Mapping;

namespace XnView.Markirator.Core.XnView.Entities;

[Table("Images")]
internal class XnViewImage
{
    [Column("ImageID")]
    public int Id { get; set; }

    [Column("FolderID")]
    public int FolderId { get; set; }

    [Column("Filename")]
    public string FileName { get; set; } = string.Empty;
}
