using LogHub.Domain.Entities.Users;

namespace LogHub.Application.Abstracts;

public interface IJwtProvider
{
    Task<string> GenerateAsync(User user);
}
