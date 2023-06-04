using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.App;
using XnView.Markirator.App.Common.UseCases.Interfaces;
using XnView.Markirator.App.UseCases.EvaluateTags;
using XnView.Markirator.App.UseCases.JsonImportTags;

Parser.Default.ParseArguments<EvaluateTags_Options, JsonImportTags_Options>(args)
    .WithParsed<EvaluateTags_Options>(options => Run<EvaluateTags_UseCase, EvaluateTags_Options>(options))
    .WithParsed<JsonImportTags_Options>(options => Run<JsonImportTags_UseCase, JsonImportTags_Options>(options));

/// <summary>
/// Running UseCase with dependency initialization
/// </summary>
static void Run<TUseCase, TOptions>(TOptions options)
    where TUseCase : IUseCase<TOptions>
{
    var services = new ServiceCollection().AddAppDependencies();

    using ServiceProvider serviceProvider = services.BuildServiceProvider();
    using IServiceScope scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

    var useCase = serviceProvider.GetRequiredService<TUseCase>();
    useCase.Execute(options);
}