using LogHub.Application.Abstracts;
using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Errors;
using LogHub.Domain.Repositories;
using LogHub.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace LogHub.Application.Users.Login;

internal sealed class LoginUserCommandHandler
    : ICommandHandler<LoginUserCommand, string>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<string>> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
        {
            return Result.Failure<string>(
                DomainErrors.User.InvalidCredentials);
        }

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.HashedPassword,
            request.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            return Result.Failure<string>(
                DomainErrors.User.InvalidCredentials);
        }

        var token = await _jwtProvider.GenerateAsync(user);

        return token;
    }
}
