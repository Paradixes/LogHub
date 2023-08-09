using Domain.Entities.Behaviours.Actions;
using Domain.Entities.Behaviours.Requests;
using Domain.Entities.Middlewares;
using Domain.Entities.Organisations;
using Domain.Entities.Records;
using Domain.Entities.Records.DataManagementPlans;
using Domain.Entities.Records.Docs;
using Domain.Entities.Records.Labels;
using Domain.Entities.Records.Logbooks;
using Domain.Entities.Records.Repositories;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Data;

public interface ILogHubDbContext
{
    DbSet<User> Users { get; set; }

    DbSet<Organisation> Organisations { get; set; }

    DbSet<RecordAction> RecordActions { get; set; }

    DbSet<RecordRequest> RecordRequests { get; set; }

    DbSet<RecordPermission> RecordPermissions { get; set; }

    DbSet<Record> Records { get; set; }

    DbSet<Question> Questions { get; set; }

    DbSet<DataManagementPlanTemplate> DataManagementPlanTemplates { get; set; }

    DbSet<DataManagementPlan> DataManagementPlans { get; set; }

    DbSet<Label> Labels { get; set; }

    DbSet<Repository> Repositories { get; set; }

    DbSet<Logbook> Logbooks { get; set; }

    DbSet<Document> Docs { get; set; }

    DbSet<DocEditor> DocEditors { get; set; }

    DbSet<FavouriteDoc> FavouriteDocs { get; set; }

    DbSet<DocLabel> DocLabels { get; set; }

    DbSet<OrganisationMembership> OrganisationMemberships { get; set; }

    DbSet<RecordCommandHandler> RecordCommandHandlers { get; set; }

    DatabaseFacade Database { get; }

    ChangeTracker ChangeTracker { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
