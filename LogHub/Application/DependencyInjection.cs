using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace LogHub.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();

            //config.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        services.AddValidatorsFromAssembly(ApplicationAssemblyReference.Assembly);

        return services;
    }
}
