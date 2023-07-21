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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LogHub.Application.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }

    DbSet<RecordEntity<RecordId>> Records { get; set; }

    DbSet<Organisation> Organisations { get; set; }

    DbSet<Question> Questions { get; set; }

    DbSet<DataManagementPlan> DataManagementPlans { get; set; }

    DbSet<Permission> Permissions { get; set; }

    DbSet<Label> Labels { get; set; }

    DbSet<Base> Bases { get; set; }

    DbSet<RecordAction> RecordActions { get; set; }

    DbSet<RecordRequest> RecordRequests { get; set; }

    DbSet<Logbook> Logbooks { get; set; }

    DbSet<Document> Docs { get; set; }

    DbSet<DocEditor> DocEditors { get; set; }

    DbSet<FavouriteDoc> FavouriteDocs { get; set; }

    DbSet<DocLabel> DocLabels { get; set; }

    DatabaseFacade Database { get; }

    ChangeTracker ChangeTracker { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}