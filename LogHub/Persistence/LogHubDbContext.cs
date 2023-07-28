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

public class LogHubDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public LogHubDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<DataManagementPlanTemplate> DataManagementPlanTemplates { get; set; }
    public DbSet<DataManagementPlan> DataManagementPlans { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<RecordAction<BaseActionId, BaseId>> BaseActions { get; set; }
    public DbSet<RecordPermission<BasePermissionId, BaseId>> BasePermissions { get; set; }
    public DbSet<RecordRequest<BaseRequestId, BaseId>> BaseRequests { get; set; }
    public DbSet<Base> Bases { get; set; }
    public DbSet<RecordAction<LogbookActionId, LogbookId>> LogbookActions { get; set; }
    public DbSet<RecordPermission<LogbookPermissionId, LogbookId>> LogbookPermissions { get; set; }
    public DbSet<RecordRequest<LogbookRequestId, LogbookId>> LogbookRequests { get; set; }
    public DbSet<Logbook> Logbooks { get; set; }
    public DbSet<RecordAction<DocActionId, DocumentId>> DocActions { get; set; }
    public DbSet<RecordPermission<DocPermissionId, DocumentId>> DocPermissions { get; set; }
    public DbSet<RecordRequest<DocRequestId, DocumentId>> DocRequests { get; set; }
    public DbSet<Document> Docs { get; set; }
    public DbSet<DocEditor> DocEditors { get; set; }
    public DbSet<FavouriteDoc> FavouriteDocs { get; set; }
    public DbSet<DocLabel> DocLabels { get; set; }

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