using Application.Abstracts.Messaging;

namespace Application.Users.Login;

public record LoginUserCommand(string Email, string Password) : ICommand<string>;