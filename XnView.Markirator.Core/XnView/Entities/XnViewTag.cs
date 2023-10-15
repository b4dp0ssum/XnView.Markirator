using LinqToDB.Mapping;

namespace XnView.Markirator.Core.XnView.Entities;

[Table("Tags")]
internal class XnViewTag
{
    [PrimaryKey, Column("TagID", IsIdentity = true, SkipOnInsert = true)]
    public int Id { get; set; }

    [Column("Label")]
    public string Label { get; set; } = string.Empty;

    [Column("ParentID")]
    public int ParentId { get; set; }

    [Column("ID")]
    public int TagGroupId { get; set; }

    public static XnViewTag GetNewInstance(string label, int parentId, int tagGroupId)
    {
        return new XnViewTag()
        {
            Label = label,
            ParentId = parentId,
            TagGroupId = tagGroupId,
        };
    }
}
