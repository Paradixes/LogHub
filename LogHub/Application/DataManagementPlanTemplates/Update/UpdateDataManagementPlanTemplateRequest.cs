using Application.DataManagementPlanTemplates.GetById;

namespace Application.DataManagementPlanTemplates.Update;

public record UpdateDataManagementPlanTemplateRequest(
    Guid Id,
    string Title,
    string? Icon,
    string? Description,
    List<QuestionResponse> Questions);