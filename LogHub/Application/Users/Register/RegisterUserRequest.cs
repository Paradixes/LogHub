using Shared.Enums;

namespace Application.Users.Register;

public record RegisterUserRequest(
    string Email,
    string Name,
    string Profession,
    string? Orcid,
    UserRole Role,
    string Password);