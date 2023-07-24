using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace LogHub.Persistence.Repositories;

public class OrganisationRepository : IOrganisationRepository
{
    private readonly LogHubDbContext _context;

    public OrganisationRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public Task<Organisation?> GetByIdAsync(OrganisationId id, CancellationToken cancellationToken = default)
    {
        return _context
            .Set<Organisation>()
            .FirstOrDefaultAsync(organisation => organisation.Id == id, cancellationToken);
    }

    public void Add(Organisation organisation)
    {
        _context.Set<Organisation>().Add(organisation);
    }

    public void Update(Organisation organisation)
    {
        _context.Set<Organisation>().Update(organisation);
    }

    public Task<Organisation?> GetByManagerIdAsync(UserId managerId, CancellationToken cancellationToken = default)
    {
        return _context
            .Set<Organisation>()
            .FirstOrDefaultAsync(organisation => organisation.ManagerId == managerId, cancellationToken);
    }
}
