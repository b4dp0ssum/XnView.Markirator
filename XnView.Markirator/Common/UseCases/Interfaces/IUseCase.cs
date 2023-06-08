namespace XnView.Markirator.App.Common.UseCases.Interfaces;

internal interface IUseCase<TInput> : IUseCase<TInput, ResultInfo>
{
    ResultInfo Execute(TInput input);
}

internal interface IUseCase<TInput, TResult>
{
}