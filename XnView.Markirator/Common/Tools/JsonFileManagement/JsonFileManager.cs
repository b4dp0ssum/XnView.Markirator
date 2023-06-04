using System.Text.Json;

namespace XnView.Markirator.App.Common.Tools.JsonFileManagement;

internal class JsonFileManager : IJsonFileManager
{
    public T? ReadJson<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }

    public async Task WriteJson<T>(string filePath, T data)
    {
        string? dir = Path.GetDirectoryName(filePath);
        
        if (dir is not null)
            Directory.CreateDirectory(dir);
        
        using FileStream openStream = File.OpenWrite(filePath);        
        await JsonSerializer.SerializeAsync(openStream, data);
    }

    public bool IsDirectory(string path)
    {
        FileAttributes attr = File.GetAttributes(path);
        return attr.HasFlag(FileAttributes.Directory);
    }
}
