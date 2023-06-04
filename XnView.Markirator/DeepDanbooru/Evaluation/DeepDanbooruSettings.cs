namespace XnView.Markirator.App.DeepDanbooru.Evaluation;

/// <summary>
/// Arguments for the 'Evaluate' DeepDanbooru command
/// </summary>
internal class DeepDanbooruSettings
{
    /// <summary>
    /// Path to the folder or image to be processed
    /// </summary>
    public string? ImagePath { get; set; }

    /// <summary>
    /// Path to the pretrained model project
    /// </summary>
    public string? ProjectPath { get; set; }

    /// <summary>
    /// Additional arguments for the 'Evaluate' command
    /// </summary>
    public string? AdditionalArgs { get; set; }
}