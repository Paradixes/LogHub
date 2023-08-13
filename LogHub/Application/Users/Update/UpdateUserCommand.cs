using Domain.Entities.Users;
using MediatR;

namespace Application.Users.Update;

public record UpdateUserCommand(
    UserId UserId,
    string Name,
    string? Avatar,
    string Profession,
    string? Orcid) : IRequest;
