using Domain.Entities.Records.DataManagementPlans;
using MediatR;

namespace Application.Records.DataManagementPlanTemplates.GetById;

public record GetDataManagementPlanTemplateByIdQuery(DataManagementPlanId Id) :
    IRequest<DataManagementPlanResponse>;