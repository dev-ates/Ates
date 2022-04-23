namespace Ates.Tool;

using Ates.Tool.Lazy;
using Ates.Tool.RandomString;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegister
{
    public static IServiceCollection AddAtesToolsServices(this IServiceCollection services)
    {
        return services
            .AddTransient(typeof(Lazy<>), typeof(Lazier<>))
            .AddSingleton<IRandomStringTool, RandomStringTool>();
    }
}
