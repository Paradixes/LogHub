using MediatR;

namespace LogHub.Application.Users.Login;

public record LoginCommand(string Email, string Password) : IRequest<string>;
