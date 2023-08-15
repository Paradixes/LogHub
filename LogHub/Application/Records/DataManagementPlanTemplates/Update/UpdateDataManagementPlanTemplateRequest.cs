using Application.Records.DataManagementPlanTemplates.GetById;

namespace Application.Records.DataManagementPlanTemplates.Update;

public record UpdateDataManagementPlanTemplateRequest(
    Guid Id,
    string Title,
    string? Icon,
    string? Description,
    List<QuestionResponse> Questions);