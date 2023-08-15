namespace Application.Records.DataManagementPlanTemplates.GetById;

public record DataManagementPlanResponse(
    Guid Id,
    Guid? OrganisationId,
    Guid CreatorId,
    string Title,
    string? Icon,
    string? Description,
    List<QuestionResponse> Questions);