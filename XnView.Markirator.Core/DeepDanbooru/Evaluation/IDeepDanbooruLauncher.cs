using XnView.Markirator.Core.Common.Entities;

namespace XnView.Markirator.Core.DeepDanbooru.Evaluation;

internal interface IDeepDanbooruLauncher
{
    ImageTagsInfo[] Evaluate(string imagePath, string projectPath, string additionalArgs);
}
