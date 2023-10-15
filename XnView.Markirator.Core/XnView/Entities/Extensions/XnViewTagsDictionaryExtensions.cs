using XnView.Markirator.Core.XnView.Entities;

internal static class XnViewTagsDictionaryExtensions
{
    public static void TryAddAll(this XnViewTagsDictionary dict, IEnumerable<XnViewTag> tags)
    {
        foreach (var tag in tags)
            dict.TryAdd(tag);
    }

    public static XnViewTag[] TryGetAll(this XnViewTagsDictionary dict, IEnumerable<string> labels)
    {
        var results = new List<XnViewTag>();

        foreach (var label in labels)
        {
            var result = dict.TryGet(label);

            if (result is not null)
            {
                results.Add(result);
            }
        }

        return results.ToArray();
    }
}
