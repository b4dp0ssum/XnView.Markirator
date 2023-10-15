using XnView.Markirator.Core.Common.Tools.OutputWriting;

namespace XnView.Markirator.Core.Common.UseCases;

internal static class ActionsHandlingExtensions
{
    public static void HandleAction(
        IOutputWriter outputWriter,
        Action action,
        string actionName,
        bool isUseCase = false)
    {
        outputWriter.WriteLine(0, $"Operation started: {actionName}");

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
            outputWriter.WriteLine(0, msg);
            throw;
        }
        finally
        {
            if (!isUseCase)
            {
                outputWriter.CurrentLevel--;
            }
        }

        outputWriter.WriteLine(0, $"Operation finished: {actionName}");
    }
}
