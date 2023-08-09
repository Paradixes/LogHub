using MediatR;

namespace Application.Users.Login;

public record LoginUserCommand(string Email, string Password) : IRequest<string>;