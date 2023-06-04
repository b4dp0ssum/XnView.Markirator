namespace XnView.Markirator.App.Common.UseCases.Interfaces;

internal interface IUseCase<TInput> : IUseCase<TInput, ResultInfo>
{
    Task<ResultInfo> Execute(TInput input);
}

internal interface IUseCase<TInput, TResult>
{
}