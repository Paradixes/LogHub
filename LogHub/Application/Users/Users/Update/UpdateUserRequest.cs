namespace Application.Users.Users.Update;

public record UpdateUserRequest(
    string Name,
    string? Avatar,
    string Profession,
    string? Orcid);