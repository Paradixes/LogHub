using LogHub.Domain.Entities.Actions;
using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Permissions;
using LogHub.Domain.Entities.Requests;
using LogHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LogHub.Application.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }

    DbSet<Organisation> Organisations { get; set; }

    DbSet<Question> Questions { get; set; }

    DbSet<DataManagementPlanTemplate> DataManagementPlanTemplates { get; set; }

    DbSet<DataManagementPlan> DataManagementPlans { get; set; }

    DbSet<Label> Labels { get; set; }

    DbSet<RecordAction<BaseActionId, BaseId>> BaseActions { get; set; }

    DbSet<RecordPermission<BasePermissionId, BaseId>> BasePermissions { get; set; }

    DbSet<RecordRequest<BaseRequestId, BaseId>> BaseRequests { get; set; }

    DbSet<Base> Bases { get; set; }

    DbSet<RecordAction<LogbookActionId, LogbookId>> LogbookActions { get; set; }

    DbSet<RecordPermission<LogbookPermissionId, LogbookId>> LogbookPermissions { get; set; }

    DbSet<RecordRequest<LogbookRequestId, LogbookId>> LogbookRequests { get; set; }

    DbSet<Logbook> Logbooks { get; set; }

    DbSet<RecordAction<DocActionId, DocumentId>> DocActions { get; set; }

    DbSet<RecordPermission<DocPermissionId, DocumentId>> DocPermissions { get; set; }

    DbSet<RecordRequest<DocRequestId, DocumentId>> DocRequests { get; set; }

    DbSet<Document> Docs { get; set; }

    DbSet<DocEditor> DocEditors { get; set; }

    DbSet<FavouriteDoc> FavouriteDocs { get; set; }

    DbSet<DocLabel> DocLabels { get; set; }

    DatabaseFacade Database { get; }

    ChangeTracker ChangeTracker { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
