using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.App.DeepDanbooru.Evaluation;

namespace XnView.Markirator.App.DeepDanbooru;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDeepDanbooru(this IServiceCollection services)
    {
        return services
            .AddSingleton(x => BuildDeepDanbooruSettings(x.GetRequiredService<IConfigurationRoot>()))
            .AddScoped<IDeepDanbooruLauncher, DeepDanbooruLauncher>();
    }

    private static DeepDanbooruSettings BuildDeepDanbooruSettings(IConfigurationRoot config)
    {
        var rootSection = config.GetSection(nameof(DeepDanbooruSettings));

        string? imagePath = rootSection
            .GetSection(nameof(DeepDanbooruSettings.ImagePath))
            .Value;

        string? projectPath = rootSection
            .GetSection(nameof(DeepDanbooruSettings.ProjectPath))
            .Value;

        string? additionalArgs = rootSection
            .GetSection(nameof(DeepDanbooruSettings.AdditionalArgs))
            .Value;

        return new DeepDanbooruSettings()
        {
            ImagePath = imagePath,
            ProjectPath = projectPath,
            AdditionalArgs = additionalArgs,
        };
    }
}