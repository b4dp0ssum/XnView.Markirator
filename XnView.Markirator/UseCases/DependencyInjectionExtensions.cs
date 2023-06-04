using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.App.UseCases.EvaluateTags;
using XnView.Markirator.App.UseCases.EvaluateTags.Tools;
using XnView.Markirator.App.UseCases.EvaluateTags.Tools.Interfaces;
using XnView.Markirator.App.UseCases.JsonImportTags;

namespace XnView.Markirator.App.UseCases;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        // ADD EvaluateTags
        services
            .AddScoped<IRequiredXnViewTagsFiller, RequiredXnViewTagsFiller>()
            .AddScoped<IXnViewFoldersFiller, XnViewFoldersFiller>()
            .AddScoped<IXnViewImagesFiller, XnViewImagesFiller>()
            .AddScoped<EvaluateTags_UseCase>();

        // ADD JsonImportTags
        services.AddScoped<JsonImportTags_UseCase>();

        return services;
    }
}
