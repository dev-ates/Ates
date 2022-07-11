namespace Ates;
using Ates.Tool;
using Ates.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
public static class ServiceRegister
{
    public static IServiceCollection AddAtesServices(this IServiceCollection services)
    {
        return services
            .AddAtesToolsServices();
    }

    public static IServiceCollection AddAtesServices<TFluentValidatorAssembly>(this IServiceCollection services, TFluentValidatorAssembly assembly, String jwtKey)
    {
        return services
            .AddAtesAspNetCoreServices(assembly, jwtKey)
            .AddAtesToolsServices();
    }
}
