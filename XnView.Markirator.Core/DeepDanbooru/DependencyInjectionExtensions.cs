using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.Core.DeepDanbooru.Evaluation;
using XnView.Markirator.Core.DeepDanbooru.Evaluation.Settings;
using XnView.Markirator.Core.DeepDanbooru.Installer;

namespace XnView.Markirator.Core.DeepDanbooru;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDeepDanbooru(this IServiceCollection services)
    {
        return services
            .AddScoped<IDeepDanbooruSettings, DeepDanbooruSettings>()
            .AddScoped<IDeepDanbooruLauncher, DeepDanbooruLauncher>()
            .AddScoped<IDeepDanbooruInstaller, DeepDanbooruInstaller>();
    }
}