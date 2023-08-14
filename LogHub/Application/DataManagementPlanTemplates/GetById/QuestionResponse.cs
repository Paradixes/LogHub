namespace Application.DataManagementPlanTemplates.GetById;

public record QuestionResponse(Guid Id, string Title, string? Description, string? Answer);