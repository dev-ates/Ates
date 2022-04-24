namespace Ates;
using Ates.Tool;
using Microsoft.Extensions.DependencyInjection;
public static class ServiceRegister
{
    public static IServiceCollection AddAtesServices(this IServiceCollection services)
    {
        return services
            .AddAtesToolsServices();
    }
}
