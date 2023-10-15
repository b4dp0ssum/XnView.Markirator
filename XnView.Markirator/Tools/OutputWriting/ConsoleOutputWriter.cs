using System.Text;
using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.Tools.ProcessingManagement;

namespace XnView.Markirator.App.Tools.OutputWriting;

internal class ConsoleOutputWriter : BaseOutputWriter
{
    // CTOR
    public ConsoleOutputWriter(
        IProcessingManager processingManager,
        int tabMultiplier = 3)
        : base(processingManager, tabMultiplier)
    {
    }

    public override void WriteLine(OutputEntry entry)
    {
        string line = BuildLine(entry.Title, entry.Timestamp);
        Console.WriteLine(line);
    }

    private string BuildLine(string str, DateTime? timestamp)
    {
        var sb = new StringBuilder();

        if (CurrentLevel < 0)
            CurrentLevel = 0;

        sb.Append(' ', CurrentLevel * TabMultiplier);

        if (timestamp is not null)
        {
            sb.Append($"[{timestamp.ToString()}] ");
        }

        sb.Append(str);
        return sb.ToString();
    }
}