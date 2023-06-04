using System.Text.RegularExpressions;

namespace XnView.Markirator.App.DeepDanbooru.Evaluation;

static class DeepDanbooruOutputParsingExtensions
{
    private static readonly Regex FilePathRegex = new(@"Tags of (.*):.*");

    public static string? TryParseFilePath(string line)
    {
        var match = FilePathRegex.Match(line);

        if (match.Success)
        {
            return match.Groups[1].Value;
        }

        return null;
    }

    private static readonly Regex TagRegex = new(@"\(.*\) (.*)");

    public static string? TryParseTag(string line)
    {
        var match = TagRegex.Match(line);

        if (match.Success)
        {
            return match.Groups[1].Value;
        }

        return null;
    }
}