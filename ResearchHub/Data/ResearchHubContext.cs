using Microsoft.EntityFrameworkCore;

namespace ResearchHub.Data
{
    public sealed class ResearchHubContext : DbContext
    {
        public ResearchHubContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
