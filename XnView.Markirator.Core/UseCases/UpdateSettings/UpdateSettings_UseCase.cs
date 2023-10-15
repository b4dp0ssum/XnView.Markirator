using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.UseCases.Interfaces;
using XnView.Markirator.Core.Common.UseCases;
using XnView.Markirator.Core.DeepDanbooru.Evaluation.Settings;
using XnView.Markirator.Core.XnView.Settings;

namespace XnView.Markirator.Core.UseCases.UpdateSettings;

internal class UpdateSettings_UseCase :
    UseCase<UpdateSettings_Options, ResultInfo>,
    IUseCase<UpdateSettings_Options>
{
    private readonly IXnViewSettings _xnViewSettings;
    private readonly IDeepDanbooruSettings _deepDanbooruSettings;

    public override string Name => "Updating Settings";

    // CTOR
    public UpdateSettings_UseCase(
        IOutputWriter outputWriter,
        IXnViewSettings xnViewSettings,
        IDeepDanbooruSettings deepDanbooruSettings)
        : base(outputWriter)
    {
        _xnViewSettings = xnViewSettings;
        _deepDanbooruSettings = deepDanbooruSettings;
    }

    protected override ResultInfo Handle(UpdateSettings_Options request)
    {
        _xnViewSettings.DbFolder = request.XnViewDbFolder;
        _xnViewSettings.ImagesCatalogPath = request.XnViewImagesCatalogPath;
        return new ResultInfo();
    }
}
