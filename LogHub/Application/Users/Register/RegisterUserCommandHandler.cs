using Application.Abstracts.Messaging;
using Domain.Entities.Users;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Register;

public class RegisterUserCommandHandler :
    ICommandHandler<RegisterUserCommand, Guid>
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

    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsEmailUniqueAsync(request.Email, cancellationToken))
        {
            return Result.Failure<Guid>(DomainErrors.User.EmailAlreadyInUse);
        }

        var user = User.Create(
            request.Name,
            request.Email,
            null,
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