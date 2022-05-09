namespace Ates.AspNetCore;

using Ates.AspNetCore.Filters;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegister
{
    public static IServiceCollection AddAtesAspNetCoreServices<TFluentValidatorAssembly>(this IServiceCollection services, TFluentValidatorAssembly assembly)
    {
        _ = services
            .AddControllers(options => options.Filters.Add<ValidationFilter>())
            .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<TFluentValidatorAssembly>())
            .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);

        return services;
    }

    public static IServiceCollection AddAtesAspNetCoreServices(this IServiceCollection services)
    {
        return services;
    }
}
