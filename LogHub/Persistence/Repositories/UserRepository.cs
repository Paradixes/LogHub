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

    public Task<List<User>> GetByOrganisationIdAsync(OrganisationId organisationId)
    {
        return _context.Users
            .Where(user => user.OrganisationMemberships.Any(membership => membership.OrganisationId == organisationId))
            .ToListAsync();
    }
}
