using Application.Data;
using Domain.Entities.Actions;
using Domain.Entities.Bases;
using Domain.Entities.DataManagementPlans;
using Domain.Entities.Docs;
using Domain.Entities.Logbooks;
using Domain.Entities.Organisations;
using Domain.Entities.Permissions;
using Domain.Entities.Requests;
using Domain.Entities.Users;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class LogHubDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public LogHubDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<Department> Departments { get; set; }

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
