using XnView.Markirator.Core.Common.Tools.ProcessingManagement;

namespace XnView.Markirator.Core.Common.Tools.OutputWriting;

public abstract class BaseOutputWriter : IOutputWriter
{
    protected readonly IProcessingManager _processingManager;

    public int CurrentLevel { get; set; } = 0;

    protected int TabMultiplier { get; private set; } = 3;

    // CTOR
    public BaseOutputWriter(IProcessingManager processingManager, int tabMultiplier = 3)
    {
        _processingManager = processingManager;
        TabMultiplier = tabMultiplier;
    }

    public abstract void WriteLine(OutputEntry entry);

    protected virtual void SetProcessingInfo(OutputEntry entry)
    {
        var processingInfo = new ProcessingInfo(entry.Step, entry.Title);
        _processingManager.SetProcessingInfo(processingInfo);
    }
}