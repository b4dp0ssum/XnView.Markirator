using CommandLine;
using System.Collections.ObjectModel;
using XnView.Markirator.Core.Common.Tools.OutputWriting;

namespace XnView.Markirator.Core.UseCases.EvaluateTags;

[Verb("evaluate", false, HelpText = "Tags evaluation command")]
public class EvaluateTags_Options
{
    [Option(longName: "path", HelpText = "Path to folder or image")]
    public string? ImagePath { get; set; }

    [Option(longName: "project", HelpText = "Path to pretrained model DeepDanbooru project")]
    public string? ProjectPath { get; set; }
}
