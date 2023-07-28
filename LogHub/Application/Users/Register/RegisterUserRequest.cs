namespace LogHub.Application.Users.Register;

public record RegisterUserRequest(
    string Email,
    string Name,
    string Profession,
    string? Orcid,
    string Role,
    string Password);
