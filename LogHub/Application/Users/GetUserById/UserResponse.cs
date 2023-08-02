using LogHub.Shared.Enums;

namespace LogHub.Application.Users.GetUserById;

public sealed record UserResponse(
    Guid Id,
    string Email,
    string Name,
    Uri? AvatarUri,
    Guid? OrganisationId,
    Guid? DepartmentId,
    string Profession,
    string? Orcid,
    UserRole Role);