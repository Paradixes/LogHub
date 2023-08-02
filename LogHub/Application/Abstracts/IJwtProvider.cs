using Domain.Entities.Users;

namespace Application.Abstracts;

public interface IJwtProvider
{
    Task<string> GenerateAsync(User user);
}