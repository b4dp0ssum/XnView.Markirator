using LinqToDB;
using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.UseCases;
using XnView.Markirator.Core.UseCases.EvaluateTags.Entities;
using XnView.Markirator.Core.UseCases.EvaluateTags.Tools.Interfaces;
using XnView.Markirator.Core.XnView.DataAccess.Repositories.Interfaces;

namespace XnView.Markirator.Core.UseCases.EvaluateTags.Tools;

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

    public void FillFolders(IReadOnlyList<AssignImageTagsInfo> fileInfoArr)
    {
        ActionsHandlingExtensions.HandleAction(
            _outputWriter,
            () => Action(fileInfoArr),
            "Fill XnView folders info");
    }

    private void Action(IReadOnlyList<AssignImageTagsInfo> fileInfoArr)
    {
        int unprocessedFoldersCounter = 0;

        var xnViewFolderPathList = fileInfoArr.Select(x => x.XnViewFolderPath).ToHashSet();

        // Find all needed entries from the Folders table in XnView
        var folders = _xnViewFoldersRepository.Find(xnViewFolderPathList);

        var foldersDict = folders.ToDictionary(x => x.FolderPath);

        for (int i = 0; i < fileInfoArr.Count(); i++)
        {
            var fileInfo = fileInfoArr[i];

            fileInfo.XnViewFolder = foldersDict.TryGetValue(fileInfo.XnViewFolderPath, out var xnViewFolder)
                ? xnViewFolder
                : null;

            if (fileInfo.XnViewFolder is null)
            {
                _outputWriter.WriteLine(i, $"WARNING: A file with an unindexed folder is detected [{fileInfo.TaggedImageInfo.FilePath}]");
                unprocessedFoldersCounter++;
            }
        }
    }
}