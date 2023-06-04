using CommandLine;

namespace XnView.Markirator.App.UseCases.JsonImportTags;

[Verb("import", false, HelpText = "Import tags from JSON command")]
internal class JsonImportTags_Options
{
    [Option(longName: "path", HelpText = "Path to JSON", Required = true)]
    public string? JsonPath { get; set; }
}
