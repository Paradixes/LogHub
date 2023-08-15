using Application.Records.DataManagementPlanTemplates.GetById;

namespace Application.Records.Repositories.Create;

public record CreateRepositoryRequest(
    Guid CreatorId,
    Guid OrganisationId,
    string Title,
    string? Description,
    string? Icon,
    DataManagementPlanResponse DataManagementPlan);