using LogHub.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace LogHub.Server.Data;

public sealed class LogHubContext : DbContext
{
    public LogHubContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
