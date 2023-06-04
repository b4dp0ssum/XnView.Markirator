using XnView.Markirator.App.Common.Tools.OutputWriting;
using XnView.Markirator.App.Common.UseCases.Interfaces;

namespace XnView.Markirator.App.Common.UseCases;

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

    public async Task<TResult> Execute(TInput input)
    {
        TResult? result = default;

        await ActionsHandlingExtensions.HandleAction(
            _outputWriter,
            async () => result = await Handle(input),
            Name);

        return result!;
    }

    protected abstract Task<TResult> Handle(TInput request);
}