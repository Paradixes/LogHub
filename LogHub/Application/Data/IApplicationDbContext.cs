using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Pages;
using LogHub.Domain.Entities.Permissions;
using LogHub.Domain.Entities.Projects;
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

    DbSet<DataManagementPlan> DataManagementPlans { get; set; }

    DbSet<Permission> Permissions { get; set; }

    DbSet<Label> Labels { get; set; }

    DbSet<Project> Projects { get; set; }

    DbSet<ProjectAction> ProjectActions { get; set; }

    DbSet<ProjectRequest> ProjectRequests { get; set; }

    DbSet<Logbook> Logbooks { get; set; }

    DbSet<Page> Pages { get; set; }

    DbSet<PageEditor> PageEditors { get; set; }

    DbSet<PageEditor> PageViewers { get; set; }

    DbSet<FavouritePage> FavouritePages { get; set; }

    DbSet<PageLabel> PageLabels { get; set; }

    DatabaseFacade Database { get; }

    ChangeTracker ChangeTracker { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
