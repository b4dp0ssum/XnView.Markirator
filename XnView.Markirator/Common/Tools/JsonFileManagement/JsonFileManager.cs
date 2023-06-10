using System.Text.Json;

namespace XnView.Markirator.App.Common.Tools.JsonFileManagement;

internal class JsonFileManager : IJsonFileManager
{
    public T? ReadJson<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }

    public void WriteJson<T>(string filePath, T data)
    {
        string? dir = Path.GetDirectoryName(filePath);

        if (dir is not null)
            Directory.CreateDirectory(dir);

        string jsonString = JsonSerializer.Serialize(data);
        File.WriteAllText(filePath, jsonString);
    }

    public bool IsDirectory(string path)
    {
        FileAttributes attr = File.GetAttributes(path);
        return attr.HasFlag(FileAttributes.Directory);
    }

    public string[] FindJson(string path)
    {
        if (this.IsDirectory(path))
        {
            return Directory.GetFiles(path, "*.json");
        }
        else
        {
            return new string[] { path };
        }
    }
}
