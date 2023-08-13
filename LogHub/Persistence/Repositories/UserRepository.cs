using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly LogHubDbContext _context;

    public UserRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public Task<User?> GetByIdAsync(UserId id)
    {
        return _context.Users
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return _context.Users
            .FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<List<Organisation>> GetOrganisationsAsync(UserId userId)
    {
        return await _context.Users
            .Where(user => user.Id == userId)
            .SelectMany(user => user.OrganisationMemberships)
            .Select(membership => membership.Organisation!)
            .ToListAsync();
    }

    public async Task<List<Organisation>> GetRootOrganisationsAsync(UserId userId)
    {
        var organisations = await _context.Users
            .Include(user => user.OrganisationMemberships)
            .ThenInclude(membership => membership.Organisation)
            .ThenInclude(organisation => organisation!.RootOrganisation)
            .Where(user => user.Id == userId)
            .SelectMany(user => user.OrganisationMemberships)
            .Select(membership => membership.Organisation)
            .ToListAsync();

        var rootOrganisations = organisations
            .Select(organisation => organisation?.RootOrganisation!)
            .Distinct()
            .ToList();

        return rootOrganisations;
    }

    public Task<bool> IsEmailUniqueAsync(string email)
    {
        return _context.Users
            .AllAsync(user => user.Email != email);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }
}
