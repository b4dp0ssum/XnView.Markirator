namespace XnView.Markirator.Core.Common.Tools.OutputWriting;

public static class OutputWriterExtensions
{
    public static void WriteLine(this IOutputWriter outputWriter, int step, string text, string? descr = null)
    {
        var entry = new OutputEntry(DateTime.Now, step, text, descr);
        outputWriter.WriteLine(entry);
    }
}