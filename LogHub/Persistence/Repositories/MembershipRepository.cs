using Domain.Entities.Middlewares;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace Persistence.Repositories;

public class MembershipRepository : IMembershipRepository
{
    private readonly LogHubDbContext _context;

    public MembershipRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public Task<OrganisationMembership?> GetByIdAsync(UserId userId, OrganisationId organisationId)
    {
        return _context.OrganisationMemberships
            .FirstOrDefaultAsync(membership => membership.UserId == userId &&
                                               membership.OrganisationId == organisationId);
    }

    public async Task<List<OrganisationMembership>> GetByParentOrganisationAsync(
        OrganisationId organisationId)
    {
        return await _context.OrganisationMemberships
            .Where(membership => membership.Organisation!.RootOrganisationId == organisationId)
            .Where(membership => membership.Organisation!.RootOrganisationId != membership.Organisation!.Id)
            .Where(membership => membership.Role == OrganisationRole.Owner)
            .Include(membership => membership.Organisation)
            .Include(membership => membership.User)
            .ToListAsync();
    }

    public async Task<List<OrganisationMembership>> GetByOrganisationIdAsync(OrganisationId organisationId)
    {
        return await _context.OrganisationMemberships
            .Where(membership => membership.OrganisationId == organisationId)
            .Include(membership => membership.User)
            .Include(membership => membership.Organisation)
            .ToListAsync();
    }

    public void Delete(OrganisationMembership membership)
    {
        _context.OrganisationMemberships.Remove(membership);
    }
}
