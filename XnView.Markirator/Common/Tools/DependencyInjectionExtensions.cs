using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.App.Common.Tools.JsonFileManagement;
using XnView.Markirator.App.Common.Tools.OutputWriting;

namespace XnView.Markirator.App.Common.Tools;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCommonTools(this IServiceCollection services)
    {
        return services
            .AddScoped<IOutputWriter, OutputWriter>()
            .AddScoped<IJsonFileManager, JsonFileManager>();
    }
}