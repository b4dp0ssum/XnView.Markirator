using XnView.Markirator.Core.UseCases.EvaluateTags;
using XnView.Markirator.Core.UseCases.GetXnViewDbFolder;
using XnView.Markirator.Core.UseCases.InstallDeepDanbooru;
using XnView.Markirator.Core.UseCases.JsonImportTags;
using XnView.Markirator.Core.UseCases.UpdateSettings;

namespace XnView.Markirator.Core;

public interface IMarkiratorService
{
    void EvaluateTags(EvaluateTags_Options options);

    void JsonImportTags(JsonImportTags_Options options);

    void InstallDeepDanbooru(InstallDeepDanbooru_Options options);

    GetSettings_ResultInfo GetSettings(GetSettings_Options options);

    void UpdateSettings(UpdateSettings_Options options);
}