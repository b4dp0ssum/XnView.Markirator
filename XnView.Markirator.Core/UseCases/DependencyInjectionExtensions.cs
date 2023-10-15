using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.Core.UseCases.EvaluateTags;
using XnView.Markirator.Core.UseCases.EvaluateTags.Tools;
using XnView.Markirator.Core.UseCases.EvaluateTags.Tools.Interfaces;
using XnView.Markirator.Core.UseCases.GetXnViewDbFolder;
using XnView.Markirator.Core.UseCases.InstallDeepDanbooru;
using XnView.Markirator.Core.UseCases.JsonImportTags;
using XnView.Markirator.Core.UseCases.UpdateSettings;

namespace XnView.Markirator.Core.UseCases;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        // ADD GetXnViewDbFolder
        services.AddScoped<GetSettings_UseCase>();

        // ADD GetXnViewDbFolder
        services.AddScoped<UpdateSettings_UseCase>();

        // ADD InstallDeepDanbooru
        services.AddScoped<InstallDeepDanbooru_UseCase>();

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
