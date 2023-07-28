using LogHub.Application.Abstracts;
using LogHub.Infrastructure.Authentication;
using LogHub.Infrastructure.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.AddScoped<IJwtProvider, JwtProvider>();
        return services;
    }
}
