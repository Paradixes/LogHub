using Application.Data;
using Domain.Entities.Events.Actions;
using Domain.Entities.Events.Requests;
using Domain.Entities.Middlewares;
using Domain.Entities.Organisations;
using Domain.Entities.Records;
using Domain.Entities.Records.DataManagementPlans;
using Domain.Entities.Records.Docs;
using Domain.Entities.Records.Labels;
using Domain.Entities.Records.Logbooks;
using Domain.Entities.Records.Repositories;
using Domain.Entities.Users;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class LogHubDbContext : DbContext, ILogHubDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public LogHubDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<RecordAction> RecordActions { get; set; }
    public DbSet<RecordRequest> RecordRequests { get; set; }
    public DbSet<RecordPermission> RecordPermissions { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<DataManagementPlanTemplate> DataManagementPlanTemplates { get; set; }
    public DbSet<DataManagementPlan> DataManagementPlans { get; set; }

    public DbSet<Label> Labels { get; set; }

    public DbSet<Repository> Repositories { get; set; }
    public DbSet<Logbook> Logbooks { get; set; }
    public DbSet<Document> Docs { get; set; }
    public DbSet<DocEditor> DocEditors { get; set; }
    public DbSet<FavouriteDoc> FavouriteDocs { get; set; }
    public DbSet<DocLabel> DocLabels { get; set; }
    public DbSet<OrganisationMembership> OrganisationMemberships { get; set; }
    public DbSet<RecordCommandHandler> RecordCommandHandlers { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var domainEvents = ChangeTracker.Entries<Entity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .SelectMany(e =>
            {
                var domainEvents = e.DomainEvents;

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LogHubDbContext).Assembly);
    }
}
