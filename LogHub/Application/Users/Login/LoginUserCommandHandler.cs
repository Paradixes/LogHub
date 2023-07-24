using LogHub.Application.Abstracts;
using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Errors;
using LogHub.Domain.Repositories;
using LogHub.Domain.Shared;

namespace LogHub.Application.Users.Login;

internal sealed class LoginUserCommandHandler
    : ICommandHandler<LoginUserCommand, string>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
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

        var token = await _jwtProvider.GenerateAsync(user);

        return token;
    }
}
