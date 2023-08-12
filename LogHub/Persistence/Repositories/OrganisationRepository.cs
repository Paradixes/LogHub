using Domain.Entities.Middlewares;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace Persistence.Repositories;

public class OrganisationRepository : IOrganisationRepository
{
    private readonly LogHubDbContext _context;

    public OrganisationRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public async Task<Organisation?> GetRootBySubIdAsync(OrganisationId id)
    {
        var organisation = await _context.Organisations
            .Include(o => o.RootOrganisation)
            .FirstOrDefaultAsync(o => o.Id == id);

        return organisation?.RootOrganisation;
    }

    public async Task<List<OrganisationMembership>> GetSubOrganisationOwnerMembershipsAsync(
        OrganisationId organisationId)
    {
        return await _context.Organisations
            .Include(o => o.SubOrganisations)
            .ThenInclude(o => o.Memberships)
            .ThenInclude(m => m.User)
            .Include(o => o.SubOrganisations)
            .ThenInclude(o => o.Memberships)
            .ThenInclude(m => m.Organisation)
            .Where(o => o.Id == organisationId)
            .SelectMany(o => o.SubOrganisations)
            .SelectMany(o => o.Memberships)
            .Where(m => m.Role == OrganisationRole.Owner)
            .ToListAsync();
    }

    public void Add(Organisation organisation)
    {
        _context.Organisations.Add(organisation);
    }

    public void Update(Organisation organisation)
    {
        _context.Organisations.Update(organisation);
    }

    public async Task<User?> GetOwnerAsync(OrganisationId organisationId)
    {
        return await _context.Users
            .Include(user => user.OrganisationMemberships)
            .ThenInclude(membership => membership.Organisation)
            .Where(user => user.OrganisationMemberships.Any(membership => membership.OrganisationId == organisationId))
            .FirstOrDefaultAsync(user =>
                user.OrganisationMemberships.Any(membership => membership.Role == OrganisationRole.Owner));
    }

    public Task<Organisation?> GetByInvitationCodeAsync(string requestInvitationCode)
    {
        return _context.Organisations
            .FirstOrDefaultAsync(o => o.InvitationCode == requestInvitationCode);
    }

    public async Task<Organisation?> GetByIdAsync(OrganisationId id)
    {
        return await _context.Organisations
            .Include(o => o.SubOrganisations)
            .Include(o => o.Memberships)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public void Delete(Organisation organisation)
    {
        _context.Organisations.Remove(organisation);
    }
}
