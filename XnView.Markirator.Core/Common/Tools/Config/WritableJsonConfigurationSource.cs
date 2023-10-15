using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace XnView.Markirator.Core.Common.Tools.Config;

public class WritableJsonConfigurationSource : JsonConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        this.EnsureDefaults(builder);
        return new WritableJsonConfigurationProvider(this);
    }
}
