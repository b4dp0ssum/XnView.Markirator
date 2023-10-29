using System.Diagnostics;

namespace XnView.Markirator.Core.DeepDanbooru.Installer;

internal class DeepDanbooruInstaller : IDeepDanbooruInstaller
{
    public void Install(string deepDanbooruPath)
    {
        InstallPip();

        var startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = @$"/k pip install ""{deepDanbooruPath}""[tensorflow]",
        };
        var process = new Process { StartInfo = startInfo };
        process.Start();
    }

    private void InstallPip()
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = @$"/c python -m ensurepip --upgrade",
        };
        var process = new Process { StartInfo = startInfo };
        process.Start();
        process.WaitForExit();
    }
}