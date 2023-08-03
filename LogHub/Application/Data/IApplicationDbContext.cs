using Domain.Entities.Actions;
using Domain.Entities.Bases;
using Domain.Entities.DataManagementPlans;
using Domain.Entities.Docs;
using Domain.Entities.Logbooks;
using Domain.Entities.Organisations;
using Domain.Entities.Permissions;
using Domain.Entities.Requests;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Data;

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