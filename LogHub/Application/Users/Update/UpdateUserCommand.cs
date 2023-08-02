using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Entities.Users;

namespace LogHub.Application.Users.Update;

public record UpdateUserCommand(
    UserId UserId,
    string Name,
    string? Avatar,
    string Profession,
    string? Orcid) : ICommand;