using Domain.Entities.Organisations;
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

    public async Task<Organisation?> GetByIdAsync(OrganisationId id)
    {
        return await _context
            .Organisations
            .Include(o => o.SubOrganisations)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}
