using LinqToDB.Mapping;

namespace XnView.Markirator.App.XnView.Entities;

[Table("TagsTree")]
internal class XnViewImageTag
{
    [Column("ImageID")]
    public int ImageId { get; set; }

    [Column("TagID")]
    public int TagId { get; set; }
}
