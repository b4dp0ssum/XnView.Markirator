using XnView.Markirator.App.Common.UseCases.Interfaces;
using System.Text.Json;
using XnView.Markirator.App.Common.Entities;
using XnView.Markirator.App.Common.Tools.OutputWriting;
using XnView.Markirator.App.UseCases.Common;
using XnView.Markirator.App.XnView.Settings;
using XnView.Markirator.App.XnView.Tools.TagsActualization;
using XnView.Markirator.App.XnView.Tools.TagsAssigning;
using System;
using XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;

namespace XnView.Markirator.App.UseCases.JsonImportTags;

internal class JsonImportTags_UseCase : BaseAssignTags_UseCase<JsonImportTags_Options>,
    IUseCase<JsonImportTags_Options>
{
    public override string Name => "Import tags from JSON";

    // CTOR
    public JsonImportTags_UseCase(
        IOutputWriter outputWriter,
        XnViewSettings xnViewSettings,
        IXnViewTagsActualizer xnViewTagsActualizer,
        IXnViewFoldersFiller xnViewFoldersFiller,
        IXnViewImagesFiller xnViewImagesFiller,
        IRequiredXnViewTagsFiller requiredXnViewTagsFiller,
        IXnViewImageTagsSetter xnViewImageTagsSetter)
        : base(outputWriter,
            xnViewSettings,
            xnViewTagsActualizer,
            xnViewFoldersFiller,
            xnViewImagesFiller,
            requiredXnViewTagsFiller,
            xnViewImageTagsSetter)
    {
    }

    protected override Task<ImageTagsInfo[]> LoadImageTagsInfo(JsonImportTags_Options input)
    {
        var json = File.ReadAllText(input.JsonPath!);
        var imageTagsInfoArr = JsonSerializer.Deserialize<ImageTagsInfo[]>(json);
        _outputWriter.Writeline($"Number of images found: {imageTagsInfoArr?.Length}");

        return Task.FromResult(imageTagsInfoArr)!;
    }
}
