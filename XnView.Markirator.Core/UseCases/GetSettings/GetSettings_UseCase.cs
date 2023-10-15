using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.UseCases.Interfaces;
using XnView.Markirator.Core.XnView.Settings;
using XnView.Markirator.Core.Common.UseCases;
using XnView.Markirator.Core.DeepDanbooru.Evaluation.Settings;
using XnView.Markirator.Core.UseCases.EvaluateTags.Tools;

namespace XnView.Markirator.Core.UseCases.GetXnViewDbFolder;

internal class GetSettings_UseCase : 
    UseCase<GetSettings_Options, GetSettings_ResultInfo>,
    IUseCase<GetSettings_Options, GetSettings_ResultInfo>
{
    private readonly IXnViewSettings _xnViewSettings;
    private readonly IDeepDanbooruSettings _deepDanbooruSettings;

    public override string Name => "Loading Settings";

    // CTOR
    public GetSettings_UseCase(
        IOutputWriter outputWriter, 
        IXnViewSettings xnViewSettings, 
        IDeepDanbooruSettings deepDanbooruSettings)
        : base(outputWriter)
    {
        _xnViewSettings = xnViewSettings;
        _deepDanbooruSettings = deepDanbooruSettings;
    }

    protected override GetSettings_ResultInfo Handle(GetSettings_Options request)
    {
        return new GetSettings_ResultInfo()
        {
            XnViewDbFolder = _xnViewSettings.DbFolder,
            ImagePath = _deepDanbooruSettings.ImagePath,
            EvaluatedTagsFolderPath = PathExtensions.GetEvaluatedTagsFolderPath(),
            XnViewImagesCatalogPath = _xnViewSettings.ImagesCatalogPath,
        };
    }
}
