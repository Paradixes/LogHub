using Application.Abstracts;
using Domain.Entities.Users;
using Domain.Exceptions.Users;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Login;

internal sealed class LoginUserCommandHandler
    : IRequestHandler<LoginUserCommand, string>
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

    public async Task<string> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user is null)
        {
            throw new UserNotFoundException(request.Email);
        }

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.HashedPassword,
            request.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new InvalidCredentialsException();
        }

        var token = await _jwtProvider.GenerateAsync(user);

        return token;
    }
}
