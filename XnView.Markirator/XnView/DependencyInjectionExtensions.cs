using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.App.XnView.DataAccess;
using XnView.Markirator.App.XnView.DataAccess.Repositories;
using XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;
using XnView.Markirator.App.XnView.Settings;
using XnView.Markirator.App.XnView.Tools.TagsActualization;
using XnView.Markirator.App.XnView.Tools.TagsAssigning;

namespace XnView.Markirator.App.XnView;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddXnView(this IServiceCollection services)
    {
        return services
            .AddSingleton(x => BuildXnViewSettings(x.GetRequiredService<IConfigurationRoot>()))
            .AddScoped<SQLiteConnection>()
            .AddScoped<IXnViewTagsRepository, XnViewTagsRepository>()
            .AddScoped<IXnViewFoldersRepository, XnViewFoldersRepository>()
            .AddScoped<IXnViewImagesRepository, XnViewImagesRepository>()
            .AddScoped<IXnViewTagsActualizer, XnViewTagsActualizer>()
            .AddScoped<IXnViewImageTagsSetter, XnViewImageTagsSetter>();
    }

    private static XnViewSettings BuildXnViewSettings(IConfigurationRoot config)
    {
        var rootSection = config.GetSection(nameof(XnViewSettings));

        string? dbFolder = rootSection
            .GetSection(nameof(XnViewSettings.DbFolder))
            .Value;

        string? imagesCatalogPath = rootSection
            .GetSection(nameof(XnViewSettings.ImagesCatalogPath))
            .Value;

        return new XnViewSettings(dbFolder!, imagesCatalogPath!);
    }
}