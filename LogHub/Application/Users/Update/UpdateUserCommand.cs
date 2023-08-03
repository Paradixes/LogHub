using Application.Abstracts.Messaging;
using Domain.Entities.Users;

namespace Application.Users.Update;

public record UpdateUserCommand(
    UserId UserId,
    string Name,
    string? Avatar,
    string Profession,
    string? Orcid) : ICommand;