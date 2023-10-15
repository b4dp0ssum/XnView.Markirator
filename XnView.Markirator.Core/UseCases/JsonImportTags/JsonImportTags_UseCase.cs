using System.Text.Json;
using XnView.Markirator.Core.Common.Entities;
using XnView.Markirator.Core.Common.Tools.JsonFileManagement;
using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.UseCases.Interfaces;
using XnView.Markirator.Core.UseCases.Common;
using XnView.Markirator.Core.UseCases.EvaluateTags.Tools;
using XnView.Markirator.Core.UseCases.EvaluateTags.Tools.Interfaces;
using XnView.Markirator.Core.XnView.Settings;
using XnView.Markirator.Core.XnView.Tools.TagsActualization;
using XnView.Markirator.Core.XnView.Tools.TagsAssigning;

namespace XnView.Markirator.Core.UseCases.JsonImportTags;

internal class JsonImportTags_UseCase : BaseAssignTags_UseCase<JsonImportTags_Options>,
    IUseCase<JsonImportTags_Options>
{
    private readonly IJsonFileManager _jsonFileManager;

    public override string Name => "Import tags from JSON";

    // CTOR
    public JsonImportTags_UseCase(
        IOutputWriter outputWriter,
        IXnViewSettings xnViewSettings,
        IXnViewTagsActualizer xnViewTagsActualizer,
        IXnViewFoldersFiller xnViewFoldersFiller,
        IXnViewImagesFiller xnViewImagesFiller,
        IRequiredXnViewTagsFiller requiredXnViewTagsFiller,
        IXnViewImageTagsSetter xnViewImageTagsSetter,
        IJsonFileManager jsonFileManager)
        : base(outputWriter,
            xnViewSettings,
            xnViewTagsActualizer,
            xnViewFoldersFiller,
            xnViewImagesFiller,
            requiredXnViewTagsFiller,
            xnViewImageTagsSetter)
    {
        _jsonFileManager = jsonFileManager ?? throw new ArgumentNullException(nameof(jsonFileManager));
    }

    protected override ImageTagsInfo[] LoadImageTagsInfo(JsonImportTags_Options input)
    {
        var allImageTags = new List<ImageTagsInfo>();

        input.JsonPath ??= PathExtensions.GetEvaluatedTagsFolderPath();
        var jsonFilePathArr = _jsonFileManager.FindJson(input.JsonPath);

        foreach (var jsonFilePath in jsonFilePathArr)
        {
            var jsonText = File.ReadAllText(jsonFilePath);
            var imageTagsInfoArr = JsonSerializer.Deserialize<ImageTagsInfo[]>(jsonText);

            if (imageTagsInfoArr is not null)
            {
                allImageTags.AddRange(imageTagsInfoArr);
            }
        }

        _outputWriter.WriteLine(0, $"Number of images found: {allImageTags.Count}");

        return allImageTags.ToArray();
    }
}
