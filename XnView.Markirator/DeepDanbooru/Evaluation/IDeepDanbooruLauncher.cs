using XnView.Markirator.App.Common.Entities;

namespace XnView.Markirator.App.DeepDanbooru.Evaluation;

internal interface IDeepDanbooruLauncher
{
    Task<ImageTagsInfo[]> Evaluate(string imagePath, string projectPath, string additionalArgs);
}
