using CommandLine;

namespace XnView.Markirator.App.UseCases.EvaluateTags;

[Verb("evaluate", false, HelpText = "Tags evaluation command")]
internal class EvaluateTags_Options
{
    [Option(longName: "path", HelpText = "Path to folder or image")]
    public string? ImagePath { get; set; }

    [Option(longName: "project", HelpText = "Path to pretrained model DeepDanbooru project")]
    public string? ProjectPath { get; set; }
}
