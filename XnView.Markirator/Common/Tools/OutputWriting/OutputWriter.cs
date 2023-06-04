using System.Text;

namespace XnView.Markirator.App.Common.Tools.OutputWriting;

internal class OutputWriter : IOutputWriter
{
    public int CurrentLevel { get; set; } = 0;

    public int TabMultiplier { get; private set; } = 3;

    // CTOR
    public OutputWriter(int tabMultiplier = 3)
    {
        TabMultiplier = tabMultiplier;
    }

    public void Writeline(string str, bool addTimestamp = true)
    {
        string line = BuildLine(str, addTimestamp);
        Console.WriteLine(line);
    }

    public string BuildLine(string str, bool addTimestamp)
    {
        var sb = new StringBuilder();

        if (CurrentLevel < 0)
            CurrentLevel = 0;

        sb.Append(' ', CurrentLevel * TabMultiplier);

        if (addTimestamp)
        {
            sb.Append($"[{DateTime.Now.ToString()}] ");
        }

        sb.Append(str);
        return sb.ToString();
    }
}