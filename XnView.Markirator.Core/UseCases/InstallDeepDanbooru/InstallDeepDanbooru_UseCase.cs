using XnView.Markirator.Core.Common.UseCases.Interfaces;
using XnView.Markirator.Core.Common.UseCases;
using XnView.Markirator.Core.DeepDanbooru.Installer;
using XnView.Markirator.Core.Common.Tools.OutputWriting;

namespace XnView.Markirator.Core.UseCases.InstallDeepDanbooru;

internal class InstallDeepDanbooru_UseCase : UseCase<InstallDeepDanbooru_Options, ResultInfo>,
    IUseCase<InstallDeepDanbooru_Options>
{
    private readonly IDeepDanbooruInstaller _installer;

    public override string Name => "Install DeepDanbooru";

    // CTOR
    public InstallDeepDanbooru_UseCase(
        IOutputWriter outputWriter,
        IDeepDanbooruInstaller installer) 
        : base(outputWriter)
    {
        _installer = installer;
    }

    protected override ResultInfo Handle(InstallDeepDanbooru_Options request)
    {
        string deepDanbooruPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "DeepDanbooru-master");

        _installer.Install(deepDanbooruPath);
        
        return new ResultInfo();
    }
}