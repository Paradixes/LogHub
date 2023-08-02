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

    public Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default)
    {
        return _context
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return _context
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
    }

    public Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default)
    {
        return _context
            .Set<User>()
            .AllAsync(user => user.Email != email, cancellationToken);
    }

    public void Add(User user)
    {
        _context.Set<User>().Add(user);
    }

    public void Update(User user)
    {
        _context.Set<User>().Update(user);
    }
}
