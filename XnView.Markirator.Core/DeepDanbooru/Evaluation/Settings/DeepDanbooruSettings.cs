using Microsoft.Extensions.Configuration;

namespace XnView.Markirator.Core.DeepDanbooru.Evaluation.Settings;

/// <summary>
/// Arguments for the 'Evaluate' DeepDanbooru command
/// </summary>
internal class DeepDanbooruSettings : IDeepDanbooruSettings
{
    private readonly IConfigurationRoot _config;

    /// <summary>
    /// Path to the folder or image to be processed
    /// </summary>
    public string? ImagePath => _config
        .GetSection(nameof(DeepDanbooruSettings))
        .GetSection(nameof(ImagePath))
        .Value;

    /// <summary>
    /// Path to the pretrained model project
    /// </summary>
    public string? ProjectPath => _config
        .GetSection(nameof(DeepDanbooruSettings))
        .GetSection(nameof(ProjectPath))
        .Value;

    /// <summary>
    /// Additional arguments for the 'Evaluate' command
    /// </summary>
    public string? AdditionalArgs => _config
        .GetSection(nameof(DeepDanbooruSettings))
        .GetSection(nameof(AdditionalArgs))
        .Value;

    // CTOR
    public DeepDanbooruSettings(IConfigurationRoot config)
    {
        _config = config;
    }
}