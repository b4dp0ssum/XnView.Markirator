using XnView.Markirator.App.Common.Tools.JsonFileManagement;
using XnView.Markirator.App.Common.Tools.OutputWriting;
using XnView.Markirator.App.Common.UseCases;
using XnView.Markirator.App.Common.UseCases.Interfaces;
using XnView.Markirator.App.DeepDanbooru.Evaluation;

namespace XnView.Markirator.App.UseCases.EvaluateTags;

internal class EvaluateTags_UseCase : UseCase<EvaluateTags_Options, ResultInfo>,
    IUseCase<EvaluateTags_Options>
{
    private readonly DeepDanbooruSettings _deepDanbooruSettings;
    private readonly IDeepDanbooruLauncher _deepDanbooruLauncher;
    private readonly IJsonFileManager _jsonFileManager;

    public override string Name => "Tags evaluation";

    // CTOR
    public EvaluateTags_UseCase(
        IOutputWriter outputWriter,
        DeepDanbooruSettings deepDanbooruSettings,
        IDeepDanbooruLauncher deepDanbooruLauncher,
        IJsonFileManager jsonFileManager)
        : base(outputWriter)
    {
        _deepDanbooruSettings = deepDanbooruSettings ?? throw new ArgumentNullException(nameof(deepDanbooruSettings));
        _deepDanbooruLauncher = deepDanbooruLauncher ?? throw new ArgumentNullException(nameof(deepDanbooruLauncher));
        _jsonFileManager = jsonFileManager ?? throw new ArgumentNullException(nameof(jsonFileManager));
    }

    protected override async Task<ResultInfo> Handle(EvaluateTags_Options input)
    {
        string imagePath = (input.ImagePath ?? _deepDanbooruSettings.ImagePath)!;
        string projectPath = (input.ProjectPath ?? _deepDanbooruSettings.ProjectPath)!;
        string additionalArgs = _deepDanbooruSettings.AdditionalArgs!;
        var imageTagsInfoArr = await _deepDanbooruLauncher.Evaluate(imagePath, projectPath, additionalArgs);

        string imageTagInfoFilePath = GetImageTagInfoFilePath();
        await _jsonFileManager.WriteJson(imageTagInfoFilePath, imageTagsInfoArr);

        return new ResultInfo();
    }

    private static string GetImageTagInfoFilePath()
    {
        string[] pathRoute = new string[]
        {
             AppDomain.CurrentDomain.BaseDirectory,
             "EvaluatedTags",
             $"Tags_{DateTime.Now:yyyy-dd-M_HH-mm-ss}.json"
        };
        return Path.Combine(pathRoute);
    }
}