namespace Application.Users.Update;

public record UpdateUserRequest(
    string Name,
    string? Avatar,
    string Profession,
    string? Orcid);