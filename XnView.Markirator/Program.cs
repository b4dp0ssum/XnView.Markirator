using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.App.Tools.OutputWriting;
using XnView.Markirator.App.Tools.ProcessingManagement;
using XnView.Markirator.Core;
using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.Tools.ProcessingManagement;
using XnView.Markirator.Core.UseCases.EvaluateTags;
using XnView.Markirator.Core.UseCases.JsonImportTags;

var services = new ServiceCollection()
    .AddScoped<IOutputWriter, ConsoleOutputWriter>()
    .AddScoped<IProcessingManager, ConsoleProcessingManager>()
    .AddMarkiratorService();

using ServiceProvider serviceProvider = services.BuildServiceProvider();
var service = serviceProvider.GetRequiredService<IMarkiratorService>();

Parser.Default.ParseArguments<EvaluateTags_Options, JsonImportTags_Options>(args)
    .WithParsed<EvaluateTags_Options>(service.EvaluateTags)
    .WithParsed<JsonImportTags_Options>(service.JsonImportTags);