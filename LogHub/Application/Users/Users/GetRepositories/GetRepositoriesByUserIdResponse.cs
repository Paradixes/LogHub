namespace Application.Users.Users.GetRepositories;

public record GetRepositoriesByUserIdResponse(
    Guid Id,
    string Title,
    string? Description,
    string? Icon,
    Guid OrganisationId,
    Guid DataManagementPlanId,
    Guid CreatorId,
    bool IsFinished);