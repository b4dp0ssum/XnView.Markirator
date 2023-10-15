using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.Tools.ProcessingManagement;

namespace XnView.Markirator.UI.Tools.OutputWriting;

internal class UiOutputWriter : BaseOutputWriter
{
    public Stack<OutputEntry> OutputEntries { get; } = new();

    public Action<OutputEntry>? Handler { get; set; }

    // CTOR
    public UiOutputWriter(
        IProcessingManager processingManager,
        int tabMultiplier = 3)
        : base(processingManager, tabMultiplier)
    {
    }

    public override void WriteLine(OutputEntry entry)
    {
        this.OutputEntries.Push(entry);
        this.Handler!(entry);
    }
}

internal static class UiOutputWriterExtensions
{
    public static Stack<OutputEntry> GetEntriesStack(this IOutputWriter outputWriter) 
        => (outputWriter as UiOutputWriter)!.OutputEntries;
}