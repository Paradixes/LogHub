using LogHub.Application.Abstracts;
using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Errors;
using LogHub.Domain.Repositories;
using LogHub.Domain.Shared;

namespace LogHub.Application.Users.Login;

internal sealed class LoginCommandHandler
    : ICommandHandler<LoginCommand, string>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<string>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
        {
            return Result.Failure<string>(
                DomainErrors.User.Registration.InvalidCredentials);
        }

        var token = await _jwtProvider.GenerateAsync(user);

        return token;
    }
}
