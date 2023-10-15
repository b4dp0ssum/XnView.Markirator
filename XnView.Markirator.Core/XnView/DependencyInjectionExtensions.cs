using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.Core.XnView.DataAccess;
using XnView.Markirator.Core.XnView.DataAccess.Repositories;
using XnView.Markirator.Core.XnView.DataAccess.Repositories.Interfaces;
using XnView.Markirator.Core.XnView.Settings;
using XnView.Markirator.Core.XnView.Tools.TagsActualization;
using XnView.Markirator.Core.XnView.Tools.TagsAssigning;

namespace XnView.Markirator.Core.XnView;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddXnView(this IServiceCollection services) => services
        .AddScoped<IXnViewSettings, XnViewSettings>()
        .AddScoped<SQLiteConnection>()
        .AddScoped<IXnViewTagsRepository, XnViewTagsRepository>()
        .AddScoped<IXnViewFoldersRepository, XnViewFoldersRepository>()
        .AddScoped<IXnViewImagesRepository, XnViewImagesRepository>()
        .AddScoped<IXnViewTagsActualizer, XnViewTagsActualizer>()
        .AddScoped<IXnViewImageTagsSetter, XnViewImageTagsSetter>();
}