using LinqToDB;
using XnView.Markirator.App.Common.Entities;
using XnView.Markirator.App.Common.Tools.OutputWriting;
using XnView.Markirator.App.Common.UseCases;
using XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;
using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.Tools.TagsActualization;

internal class XnViewTagsActualizer : IXnViewTagsActualizer
{
    private readonly IOutputWriter _outputWriter;
    private readonly IXnViewTagsRepository _tagsRepo;

    // CTOR
    public XnViewTagsActualizer(IOutputWriter outputWriter, IXnViewTagsRepository tagsRepo)
    {
        _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
        _tagsRepo = tagsRepo ?? throw new ArgumentNullException(nameof(tagsRepo));
    }

    public XnViewTagsDictionary UpdateAndLoadTags(IEnumerable<ImageTagsInfo> fileInfoArr)
    {
        XnViewTagsDictionary? result = null;

        ActionsHandlingExtensions.HandleAction(
            _outputWriter,
            () => result = Action(fileInfoArr),
            "Updating XnView categories");

        return result!;
    }

    private XnViewTagsDictionary Action(IEnumerable<ImageTagsInfo> fileInfoArr)
    {
        var result = new XnViewTagsDictionary();

        var newTags = fileInfoArr.SelectMany(x => x.Tags).ToHashSet();
        _outputWriter.Writeline($"Total number of categories to update: {newTags.Count}");

        // Find the root tag
        var rootBooruTag = _tagsRepo.Find(TagsConstants.RootTagLabel, TagsConstants.RootTagsParentId);

        // If root tag does not exist in the database, let's create it
        if (rootBooruTag is null)
        {
            rootBooruTag = new XnViewTag()
            {
                Label = TagsConstants.RootTagLabel,
                ParentId = TagsConstants.RootTagsParentId,
                TagGroupId = 0,
            };
            _tagsRepo.Create(rootBooruTag);
            _outputWriter.Writeline("A root category was created");
        }

        // Load existing tags from the database that overlap with our set of new tags
        var existedTags = _tagsRepo.Find(newTags, rootBooruTag.Id);
        var exitedTagsLabels = existedTags.Select(x => x.Label).ToHashSet();

        int maxi = _tagsRepo.GetMaxGroupPosition(rootBooruTag.Id);

        var tagsToCreate = newTags
            .Except(exitedTagsLabels)
            .Select(x => XnViewTag.GetNewInstance(x!, rootBooruTag.Id, maxi++))
            .ToArray();

        _outputWriter.Writeline($"Number of missing categories: {tagsToCreate.Length}");

        _tagsRepo.InsertAll(tagsToCreate);

        // Reload the database entries so they already have identifiers
        existedTags = _tagsRepo.Find(newTags, rootBooruTag.Id);
        result.TryAddAll(existedTags);

        return result;
    }
}