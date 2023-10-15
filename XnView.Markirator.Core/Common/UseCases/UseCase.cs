using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.UseCases.Interfaces;

namespace XnView.Markirator.Core.Common.UseCases;

internal abstract class UseCase<TInput, TResult> : IUseCase<TInput, TResult>
    where TResult : ResultInfo, new()
{
    protected readonly IOutputWriter _outputWriter;

    public abstract string Name { get; }

    // CTOR
    public UseCase(IOutputWriter outputWriter)
    {
        _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
    }

    public TResult Execute(TInput input)
    {
        TResult? result = default;

        ActionsHandlingExtensions.HandleAction(
            _outputWriter,
            () => result = Handle(input),
            Name);

        return result!;
    }

    protected abstract TResult Handle(TInput request);
}