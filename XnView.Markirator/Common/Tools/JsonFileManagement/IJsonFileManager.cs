namespace XnView.Markirator.App.Common.Tools.JsonFileManagement
{
    internal interface IJsonFileManager
    {
        T? ReadJson<T>(string filePath);
        void WriteJson<T>(string filePath, T data);
        bool IsDirectory(string path);
        string[] FindJson(string path);
    }
}