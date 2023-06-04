using LinqToDB;
using XnView.Markirator.App.Common.Tools.OutputWriting;
using XnView.Markirator.App.Common.UseCases;
using XnView.Markirator.App.UseCases.EvaluateTags.Entities;
using XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;
using XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;

namespace XnView.Markirator.App.UseCases.EvaluateTags.Tools;

internal class XnViewFoldersFiller : IXnViewFoldersFiller
{
    private readonly IOutputWriter _outputWriter;
    private readonly IXnViewFoldersRepository _xnViewFoldersRepository;

    // CTOR
    public XnViewFoldersFiller(IOutputWriter outputWriter, IXnViewFoldersRepository xnViewFoldersRepository)
    {
        _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
        _xnViewFoldersRepository = xnViewFoldersRepository ?? throw new ArgumentNullException(nameof(xnViewFoldersRepository));
    }

    public Task FillFolders(IEnumerable<AssignImageTagsInfo> fileInfoArr)
    {
        return ActionsHandlingExtensions.HandleAction(
            _outputWriter,
            () => Action(fileInfoArr),
            "Fill XnView folders info");
    }

    private async Task Action(IEnumerable<AssignImageTagsInfo> fileInfoArr)
    {
        int unprocessedFoldersCounter = 0;

        var xnViewFolderPathList = fileInfoArr.Select(x => x.XnViewFolderPath).ToHashSet();

        // Find all needed entries from the Folders table in XnView
        var folders = await _xnViewFoldersRepository.Find(xnViewFolderPathList);

        var foldersDict = folders.ToDictionary(x => x.FolderPath);

        foreach (var fileInfo in fileInfoArr)
        {
            fileInfo.XnViewFolder = foldersDict.TryGetValue(fileInfo.XnViewFolderPath, out var xnViewFolder)
                ? xnViewFolder
                : null;

            if (fileInfo.XnViewFolder is null)
            {
                _outputWriter.Writeline($"WARNING: A file with an unindexed folder is detected [{fileInfo.TaggedImageInfo.FilePath}]");
                unprocessedFoldersCounter++;
            }
        }
    }
}