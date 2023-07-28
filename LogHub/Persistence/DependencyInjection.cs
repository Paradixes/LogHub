using LogHub.Application.Data;
using LogHub.Domain.Repositories;
using LogHub.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogHub.Persistence;

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

        services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<LogHubDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<LogHubDbContext>());

        // TODO: Add repositories here
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrganisationRepository, OrganisationRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        return services;
    }
}
