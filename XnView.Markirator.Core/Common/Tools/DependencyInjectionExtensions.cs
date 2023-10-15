using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.Core.Common.Tools.JsonFileManagement;

namespace XnView.Markirator.Core.Common.Tools;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCommonTools(this IServiceCollection services)
    {
        return services
            .AddScoped<IJsonFileManager, JsonFileManager>();
    }
}