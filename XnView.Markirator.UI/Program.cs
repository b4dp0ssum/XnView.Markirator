using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.Core;
using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.Tools.ProcessingManagement;
using XnView.Markirator.UI.Tools.OutputWriting;
using XnView.Markirator.UI.Tools.ProcessingManagement;

namespace XnView.Markirator.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection()
                .AddSingleton<IOutputWriter, UiOutputWriter>()
                .AddScoped<IProcessingManager, UiProcessingManager>()
                .AddMarkiratorService()
                .AddSingleton<MainForm>();

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            var mainForm = serviceProvider.GetRequiredService<MainForm>();

            Application.Run(mainForm);
        }
    }
}