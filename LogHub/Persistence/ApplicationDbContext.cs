using LogHub.Application.Data;
using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Pages;
using LogHub.Domain.Entities.Permissions;
using LogHub.Domain.Entities.Projects;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LogHub.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<DataManagementPlan> DataManagementPlans { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectAction> ProjectActions { get; set; }
    public DbSet<ProjectRequest> ProjectRequests { get; set; }
    public DbSet<Logbook> Logbooks { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<PageEditor> PageEditors { get; set; }
    public DbSet<PageEditor> PageViewers { get; set; }
    public DbSet<FavouritePage> FavouritePages { get; set; }
    public DbSet<PageLabel> PageLabels { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var domainEvents = ChangeTracker.Entries<Entity<EntityId>>()
            .Select(e => e.Entity)
            .Where(e => e.GetDomainEvents().Any())
            .SelectMany(e =>
            {
                var domainEvents = e.GetDomainEvents();

                e.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
