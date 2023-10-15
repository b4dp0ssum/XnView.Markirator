using XnView.Markirator.Core.Common.UseCases;

namespace XnView.Markirator.Core.UseCases.GetXnViewDbFolder;

public class GetSettings_ResultInfo : ResultInfo
{
    public string? XnViewDbFolder { get; set; }

    public string? ImagePath { get; set; }

    public string? EvaluatedTagsFolderPath { get; set; }

    public string? XnViewImagesCatalogPath { get; set; }
}
