using Application.Records.DataManagementPlanTemplates.GetById;

namespace Application.Records.DataManagementPlanTemplates.Create;

public record CreateDataManagementPlanTemplateRequest(
    Guid OrganisationId,
    Guid CreatorId,
    string Title,
    string? Icon,
    string? Description,
    List<QuestionResponse> Questions);