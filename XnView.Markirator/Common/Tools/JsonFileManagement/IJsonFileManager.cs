﻿namespace XnView.Markirator.App.Common.Tools.JsonFileManagement
{
    internal interface IJsonFileManager
    {
        T? ReadJson<T>(string filePath);
        Task WriteJson<T>(string filePath, T data);
        bool IsDirectory(string path);  
    }
}