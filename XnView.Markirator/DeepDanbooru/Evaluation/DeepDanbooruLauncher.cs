using System.Diagnostics;
using System.Text;
using XnView.Markirator.App.Common.Entities;
using XnView.Markirator.App.Common.Tools.OutputWriting;
using XnView.Markirator.App.Common.UseCases;

namespace XnView.Markirator.App.DeepDanbooru.Evaluation;

internal class DeepDanbooruLauncher : IDeepDanbooruLauncher
{
    private readonly IOutputWriter _outputWriter;

    // CTOR
    public DeepDanbooruLauncher(IOutputWriter outputWriter)
    {
        _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
    }

    public ImageTagsInfo[] Evaluate(string imagePath, string projectPath, string additionalArgs)
    {
        ImageTagsInfo[]? result = null;

        ActionsHandlingExtensions.HandleAction(
            _outputWriter,
            () => Task.FromResult(result = Action(imagePath, projectPath, additionalArgs)),
            "Evaluating tags by DeepDanbooru");

        return result!;
    }

    private ImageTagsInfo[] Action(string imagePath, string projectPath, string additionalArgs)
    {
        Process process = StartProcessForEvaluate(imagePath, projectPath, additionalArgs);

        var fileInfoArr = new List<ImageTagsInfo>();
        ImageTagsInfo? currentFileInfo = null;

        while (!process.StandardOutput.EndOfStream)
        {
            string line = process.StandardOutput.ReadLine() ?? string.Empty;

            string? filePath = DeepDanbooruOutputParsingExtensions.TryParseFilePath(line);
            if (!string.IsNullOrEmpty(filePath))
            {
                if (currentFileInfo != null)
                {
                    this.LogFileInfo(currentFileInfo);
                    fileInfoArr.Add(currentFileInfo);
                }
                currentFileInfo = new ImageTagsInfo(filePath!);
                continue;
            }

            if (currentFileInfo != null)
            {
                string? tag = DeepDanbooruOutputParsingExtensions.TryParseTag(line);
                if (!string.IsNullOrEmpty(tag))
                {
                    currentFileInfo.Tags.Add(tag);
                }
            }
        }

        if (currentFileInfo is not null && !fileInfoArr.Contains(currentFileInfo))
        {
            fileInfoArr.Add(currentFileInfo);
            this.LogFileInfo(currentFileInfo);
        }            

        return fileInfoArr.ToArray();
    }

    private Process StartProcessForEvaluate(string imagePath, string projectPath, string additionalArgs)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = BuildArgsForEvaluate(imagePath, projectPath, additionalArgs),
            UseShellExecute = false,
            RedirectStandardOutput = true
        };
        var process = new Process { StartInfo = startInfo };
        process.Start();

        return process;
    }

    private string BuildArgsForEvaluate(string imagePath, string projectPath, string additionalArgs)
    {
        var sb = new StringBuilder();
        sb.Append(@$"/C deepdanbooru evaluate {imagePath} ");
        sb.Append($"--project-path {projectPath}");

        if (!string.IsNullOrEmpty(additionalArgs))
        {
            sb.Append(' ');
            sb.Append(additionalArgs);
        }

        return sb.ToString();
    }

    private void LogFileInfo(ImageTagsInfo fileInfo) 
        => _outputWriter.Writeline($"{fileInfo.FilePath} [Categories: {fileInfo.Tags.Count}]");
}