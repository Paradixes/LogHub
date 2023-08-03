using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class OrganisationRepository : IOrganisationRepository
{
    private readonly LogHubDbContext _context;

    public OrganisationRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public void Add(Organisation organisation)
    {
        _context.Set<Organisation>().Add(organisation);
    }

    public void Update(Organisation organisation)
    {
        _context.Set<Organisation>().Update(organisation);
    }

    public Task<Organisation?> GetByManagerIdAsync(UserId managerId)
    {
        return _context
            .Set<Organisation>()
            .FirstOrDefaultAsync(organisation => organisation.ManagerId == managerId);
    }

    public async Task<Organisation?> GetByIdAsync(OrganisationId id)
    {
        return await _context
            .Organisations
            .Include(o => o.Departments)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}
