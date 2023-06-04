using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.App.Common.Tools;
using XnView.Markirator.App.DeepDanbooru;
using XnView.Markirator.App.UseCases;
using XnView.Markirator.App.XnView;

namespace XnView.Markirator.App;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddAppDependencies(this IServiceCollection services)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        IConfigurationRoot configuration = builder.Build();
        services.AddSingleton(configuration);

        services.AddCommonTools();
        services.AddDeepDanbooru();
        services.AddXnView();
        services.AddUseCases();

        return services;
    }
}