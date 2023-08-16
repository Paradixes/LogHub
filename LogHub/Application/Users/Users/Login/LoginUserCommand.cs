using MediatR;

namespace Application.Users.Users.Login;

public record LoginUserCommand(string Email, string Password) : IRequest<string>;