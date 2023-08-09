using Domain.Entities.Users;
using Domain.Exceptions.Users;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Register;

public class RegisterUserCommandHandler :
    IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsEmailUniqueAsync(request.Email))
        {
            throw new UserEmailNotUniqueException(request.Email);
        }

        var user = User.Create(
            request.Name,
            request.Email,
            null,
            request.Profession,
            request.Orcid,
            request.Role);
        var hashedPassword = _passwordHasher.HashPassword(user, request.Password);
        user.ChangePassword(hashedPassword);

        _userRepository.Add(user);
        return user.Id.Value;
    }
}
