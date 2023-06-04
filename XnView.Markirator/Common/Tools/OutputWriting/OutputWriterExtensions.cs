namespace XnView.Markirator.App.Common.Tools.OutputWriting;

internal static class OutputWriterExtensions
{
    public static async Task HandleUseCase(this IOutputWriter outputWriter, Func<Task> action)
    {
        outputWriter.CurrentLevel = 0;
        outputWriter.Writeline($"Начинаем актуализацию категорий");
        outputWriter.CurrentLevel = 1;

        await action();

        outputWriter.CurrentLevel = 0;
        outputWriter.Writeline($"Актуализация категорий завершена");
    }
}