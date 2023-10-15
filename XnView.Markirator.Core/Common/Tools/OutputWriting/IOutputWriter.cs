namespace XnView.Markirator.Core.Common.Tools.OutputWriting;

public interface IOutputWriter
{
    int CurrentLevel { get; set; }

    void WriteLine(OutputEntry entry);
}
