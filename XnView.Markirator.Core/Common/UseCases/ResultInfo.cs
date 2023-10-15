namespace XnView.Markirator.Core.Common.UseCases;

public class ResultInfo
{
    public ResultEnum Result { get; set; } = ResultEnum.Success;

    public string? Message { get; set; }
}
