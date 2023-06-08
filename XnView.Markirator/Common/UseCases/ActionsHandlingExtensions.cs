using XnView.Markirator.App.Common.Tools.OutputWriting;

namespace XnView.Markirator.App.Common.UseCases;

internal static class ActionsHandlingExtensions
{
    public static void HandleAction(
        IOutputWriter outputWriter,
        Action action,
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
            action();
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
