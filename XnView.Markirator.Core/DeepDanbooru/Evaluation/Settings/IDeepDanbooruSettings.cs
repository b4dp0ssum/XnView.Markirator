namespace XnView.Markirator.Core.DeepDanbooru.Evaluation.Settings
{
    internal interface IDeepDanbooruSettings
    {
        string? AdditionalArgs { get; }
        string? ImagePath { get; }
        string? ProjectPath { get; }
    }
}