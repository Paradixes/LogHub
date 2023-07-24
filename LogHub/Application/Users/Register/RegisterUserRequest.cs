namespace LogHub.Application.Users.Register;

public record RegisterUserRequest(
    string Email,
    string Name,
    Guid? OrganisationId,
    Guid? DepartmentId,
    string Profession,
    string? Orcid,
    string Role,
    string Password);
