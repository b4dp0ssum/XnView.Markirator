using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using XnView.Markirator.Core.Common.Tools;
using XnView.Markirator.Core.Common.Tools.Config;
using XnView.Markirator.Core.DeepDanbooru;
using XnView.Markirator.Core.UseCases;
using XnView.Markirator.Core.XnView;

namespace XnView.Markirator.Core;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddMarkiratorService(this IServiceCollection services)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory());

        IConfigurationRoot configuration = builder
            .Add<WritableJsonConfigurationSource>(
                s =>
                {
                    s.FileProvider = null;
                    s.Path = "appsettings.json";
                    s.Optional = false;
                    s.ReloadOnChange = true;
                    s.ResolveFileProvider();
                })
            .Build();

        services.AddSingleton(configuration);

        services.AddCommonTools();
        services.AddDeepDanbooru();
        services.AddXnView();
        services.AddUseCases();

        services.AddSingleton<IMarkiratorService, MarkiratorService>();

        return services;
    }
}