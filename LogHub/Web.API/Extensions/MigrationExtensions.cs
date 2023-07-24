using LogHub.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LogHub.Web.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<LogHubDbContext>();

        dbContext.Database.Migrate();
    }
}