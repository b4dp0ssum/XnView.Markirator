namespace XnView.Markirator.Core.Common.UseCases.Interfaces;

internal interface IUseCase<TInput> : IUseCase<TInput, ResultInfo>
{    
}

internal interface IUseCase<TInput, TResult>
{
    TResult Execute(TInput input);
}