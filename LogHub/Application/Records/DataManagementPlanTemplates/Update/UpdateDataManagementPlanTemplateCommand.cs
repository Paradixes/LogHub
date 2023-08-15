using Application.Records.DataManagementPlanTemplates.GetById;
using Domain.Entities.Records.DataManagementPlans;
using MediatR;

namespace Application.Records.DataManagementPlanTemplates.Update;

public record UpdateDataManagementPlanTemplateCommand(
    DataManagementPlanId Id,
    string Title,
    string? Icon,
    string? Description,
    List<QuestionResponse> Questions) : IRequest;