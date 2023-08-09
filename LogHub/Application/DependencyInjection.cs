using Application.Behaviours;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();

            config.AddOpenBehavior(typeof(UnitOfWorkBehaviour<,>));
        });

        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        return services;
    }
}