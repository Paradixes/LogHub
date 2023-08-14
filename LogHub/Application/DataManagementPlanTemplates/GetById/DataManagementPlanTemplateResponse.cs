namespace Application.DataManagementPlanTemplates.GetById;

public record DataManagementPlanTemplateResponse(
    Guid Id,
    Guid? OrganisationId,
    Guid CreatorId,
    string Title,
    string? Icon,
    string? Description,
    List<QuestionResponse> Questions);
