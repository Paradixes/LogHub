using Application.DataManagementPlanTemplates.GetById;

namespace Application.DataManagementPlanTemplates.Create;

public record CreateDataManagementPlanTemplateRequest(
    Guid OrganisationId,
    Guid CreatorId,
    string Title,
    string? Icon,
    string? Description,
    List<QuestionResponse> Questions);