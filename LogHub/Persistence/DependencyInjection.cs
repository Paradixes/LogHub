using Application.Data;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LogHubDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Database"));
        });

        services.AddScoped<ILogHubDbContext>(sp =>
            sp.GetRequiredService<LogHubDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<LogHubDbContext>());

        // TODO: Add repositories here
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrganisationRepository, OrganisationRepository>();
        services.AddScoped<IMembershipRepository, MembershipRepository>();

        return services;
    }
}
