using LogHub.Application.Abstracts.Messaging;

namespace LogHub.Application.Users.Login;

public record LoginCommand(string Email, string Password) : ICommand<string>;
