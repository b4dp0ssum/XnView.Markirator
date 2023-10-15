using XnView.Markirator.Core.Common.Tools.ProcessingManagement;

namespace XnView.Markirator.UI.Tools.ProcessingManagement;

internal class UiProcessingManager : IProcessingManager
{
    public Action<ProcessingInfo>? Handler { get; set; }

    public void SetProcessingInfo(ProcessingInfo processingInfo)
        => this.Handler!(processingInfo);
}
