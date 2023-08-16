using Application.Records.DataManagementPlanTemplates.GetById;

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
    DataManagementPlanResponse DataManagementPlan);
