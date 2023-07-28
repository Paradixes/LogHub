using LogHub.Application.Abstracts.Messaging;

namespace LogHub.Application.Users.Login;

public record LoginUserCommand(string Email, string Password) : ICommand<string>;