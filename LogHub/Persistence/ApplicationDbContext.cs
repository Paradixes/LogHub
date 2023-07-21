using LogHub.Application.Data;
using LogHub.Domain.Entities.Actions;
using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Permissions;
using LogHub.Domain.Entities.Requests;
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

    public DbSet<RecordEntity<RecordId>> Records { get; set; } = null!;

    public DbSet<Organisation> Organisations { get; set; } = null!;

    public DbSet<Question> Questions { get; set; } = null!;

    public DbSet<DataManagementPlan> DataManagementPlans { get; set; } = null!;

    public DbSet<Permission> Permissions { get; set; } = null!;

    public DbSet<Label> Labels { get; set; } = null!;

    public DbSet<Base> Bases { get; set; } = null!;

    public DbSet<RecordAction> RecordActions { get; set; } = null!;

    public DbSet<RecordRequest> RecordRequests { get; set; } = null!;

    public DbSet<Logbook> Logbooks { get; set; } = null!;

    public DbSet<Document> Docs { get; set; } = null!;

    public DbSet<DocEditor> DocEditors { get; set; } = null!;

    public DbSet<FavouriteDoc> FavouriteDocs { get; set; } = null!;

    public DbSet<DocLabel> DocLabels { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var domainEvents = ChangeTracker.Entries<Entity>()
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
