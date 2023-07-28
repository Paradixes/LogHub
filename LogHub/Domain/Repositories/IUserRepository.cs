using LogHub.Domain.Entities.Users;

namespace LogHub.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);

    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);

    void Add(User user);

    void Update(User user);
}
