using Application.Abstracts;
using Infrastructure.Authentication;
using Infrastructure.OptionsSetup;
using Infrastructure.Storage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

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

        services.AddScoped<IBlobStorageProvider, BlobStorageProvider>(
            p => new BlobStorageProvider(configuration.GetConnectionString("Storage"))
        );

        services.AddScoped<IJwtProvider, JwtProvider>();


        return services;
    }
}