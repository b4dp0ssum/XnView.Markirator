using XnView.Markirator.App.Common.Tools.JsonFileManagement;
using XnView.Markirator.App.Common.Tools.OutputWriting;
using XnView.Markirator.App.Common.UseCases;
using XnView.Markirator.App.Common.UseCases.Interfaces;
using XnView.Markirator.App.DeepDanbooru.Evaluation;
using XnView.Markirator.App.UseCases.EvaluateTags.Tools;

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

    protected override ResultInfo Handle(EvaluateTags_Options input)
    {
        string imagePath = (input.ImagePath ?? _deepDanbooruSettings.ImagePath)!;
        string projectPath = (input.ProjectPath ?? _deepDanbooruSettings.ProjectPath)!;
        string additionalArgs = _deepDanbooruSettings.AdditionalArgs!;
        var imageTagsInfoArr = _deepDanbooruLauncher.Evaluate(imagePath, projectPath, additionalArgs);

        string imageTagInfoFilePath = GetImageTagInfoFilePath(imagePath);
        _jsonFileManager.WriteJson(imageTagInfoFilePath, imageTagsInfoArr);
        _outputWriter.Writeline($"Evaluated tags saved into file: [{imageTagInfoFilePath}]");

        return new ResultInfo();
    }

    private static string GetImageTagInfoFilePath(string imagePath)
    {
        string[] pathRoute = new string[]
        {
             PathExtensions.GetEvaluatedTagsFolderPath(),
             $"{Path.GetFileName(Path.GetDirectoryName(imagePath))}_{DateTime.Now:yyyy-dd-M_HH-mm-ss}.json"
        };
        return Path.Combine(pathRoute);
    }
}