using Domain.Entities.Organisations;
using Domain.Entities.Records.Repositories;
using Domain.Entities.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class RepositoryRepository : IRepositoryRepository
{
    private readonly LogHubDbContext _context;

    public RepositoryRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public void Add(Repository repository)
    {
        _context.Repositories.Add(repository);
    }

    public void Delete(Repository repository)
    {
        _context.Repositories.Remove(repository);
    }

    public async Task<Repository?> GetByIdAsync(RepositoryId id)
    {
        return await _context.Repositories
            .Include(r => r.DataManagementPlan)
            .ThenInclude(dmp => dmp!.Questions)
            .Include(r => r.DataManagementPlan)
            .ThenInclude(dmp => dmp!.Permissions)
            .Include(r => r.Organisation)
            .Include(r => r.Permissions)
            .Include(r => r.Labels)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Repository>> GetByOrganisationIdAsync(OrganisationId organisationId)
    {
        return await _context.Repositories
            .Include(r => r.DataManagementPlan)
            .Include(r => r.Permissions)
            .Where(r => r.OrganisationId == organisationId)
            .ToListAsync();
    }

    public async Task<List<Repository>> GetByUserIdAsync(UserId userId)
    {
        return await _context.Repositories
            .Include(r => r.DataManagementPlan)
            .Include(r => r.Permissions)
            .Where(r => r.Permissions.Any(p => p.UserId == userId))
            .ToListAsync();
    }
}
