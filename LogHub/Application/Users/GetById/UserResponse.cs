using Shared.Enums;

namespace Application.Users.GetById;

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