using Application.Records.DataManagementPlanTemplates.GetById;
using Application.Users.Users.GetById;

namespace Application.Records.Repositories.GetById;

public record RepositoryResponse(
    Guid Id,
    string Title,
    string? Description,
    string? Icon,
    Guid OrganisationId,
    Guid DataManagementPlanId,
    Guid CreatorId,
    bool IsFinished,
    UserResponse Creator,
    DataManagementPlanResponse DataManagementPlan);
