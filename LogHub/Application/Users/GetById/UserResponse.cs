using Shared.Enums;

namespace Application.Users.GetById;

public sealed record UserResponse(
    Guid Id,
    string Email,
    string Name,
    Uri? AvatarUri,
    string Profession,
    string? Orcid,
    UserRole Role);