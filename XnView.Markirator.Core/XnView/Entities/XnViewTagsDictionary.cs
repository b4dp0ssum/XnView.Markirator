namespace XnView.Markirator.Core.XnView.Entities;

internal class XnViewTagsDictionary
{
    private readonly Dictionary<string, XnViewTag> _dict = new();

    // CTOR
    public XnViewTagsDictionary(IEnumerable<XnViewTag>? tags = null)
    {
        if (tags is null)
            return;

        foreach (var tag in tags)
        {
            TryAdd(tag);
        }
    }

    public void TryAdd(XnViewTag tag)
        => _dict.TryAdd(tag.Label!, tag);

    public XnViewTag? TryGet(string label)
        => _dict.TryGetValue(label, out var tag) ? tag : null;
}