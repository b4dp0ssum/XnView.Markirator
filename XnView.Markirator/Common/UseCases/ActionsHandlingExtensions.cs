using XnView.Markirator.App.Common.Tools.OutputWriting;

namespace XnView.Markirator.App.Common.UseCases;

internal static class ActionsHandlingExtensions
{
    public static async Task HandleAction(
        IOutputWriter outputWriter,
        Func<Task> action,
        string actionName,
        bool isUseCase = false)
    {
        outputWriter.Writeline(actionName);

        if (!isUseCase)
        {
            outputWriter.CurrentLevel++;
        }

        try
        {
            await action();
        }
        catch (Exception ex)
        {
            string msg = $"ERROR ON [{actionName}]: {ex}";
            outputWriter.Writeline(msg);
            throw;
        }
        finally
        {
            if (!isUseCase)
            {
                outputWriter.CurrentLevel--;
            }
        }
    }
}
