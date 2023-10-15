using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;

namespace XnView.Markirator.Core.Common.Tools.Config;

public class WritableJsonConfigurationProvider : JsonConfigurationProvider
{
    // CTOR
    public WritableJsonConfigurationProvider(JsonConfigurationSource source)
        : base(source)
    {
    }

    public override void Set(string key, string? value)
    {
        base.Set(key, value);

        //Get Whole json file and change only passed key with passed value. It requires modification if you need to support change multi level json structure
        var fileFullPath = base.Source!.FileProvider?.GetFileInfo(base.Source!.Path!).PhysicalPath;
        string json = File.ReadAllText(fileFullPath!);
        dynamic jsonObj = JsonConvert.DeserializeObject(json)!;

        dynamic node = jsonObj;
        var subKeys = key.Split(':');
        for (int i = 0; i < subKeys.Length; i++)
        {
            string k = subKeys[i];
            if (subKeys.Length - 1 == i)
            {
                node[k] = value;
            }
            else
            {
                node = node[k];
            }
        }

        string output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(fileFullPath!, output);
    }
}
