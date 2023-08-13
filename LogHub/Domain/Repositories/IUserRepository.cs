using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(UserId id);

    Task<User?> GetByEmailAsync(string email);

    Task<List<Organisation>> GetOrganisationsAsync(UserId userId);

    Task<List<Organisation>> GetRootOrganisationsAsync(UserId userId);

    Task<bool> IsEmailUniqueAsync(string email);

    void Add(User user);

    void Update(User user);
}
