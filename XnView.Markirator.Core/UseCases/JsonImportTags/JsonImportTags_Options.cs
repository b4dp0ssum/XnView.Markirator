using CommandLine;

namespace XnView.Markirator.Core.UseCases.JsonImportTags;

[Verb("import", false, HelpText = "Import tags from JSON command")]
public class JsonImportTags_Options
{
    [Option(longName: "path", HelpText = "Path to JSON")]
    public string? JsonPath { get; set; }
}
