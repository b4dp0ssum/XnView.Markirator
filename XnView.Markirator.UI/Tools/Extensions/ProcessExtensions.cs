using System.Diagnostics;

namespace XnView.Markirator.UI.Tools.Extensions;

internal static class ProcessExtensions
{
    public static void LaunchBrowser(string url)
    {
        var proc = new Process();
        proc.StartInfo.UseShellExecute = true;
        proc.StartInfo.FileName = url;
        proc.Start();
    }
}
