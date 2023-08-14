using Domain.Entities.Records.DataManagementPlans;
using MediatR;

namespace Application.DataManagementPlanTemplates.GetById;

public record GetDataManagementPlanTemplateByIdQuery(DataManagementPlanId Id) :
    IRequest<DataManagementPlanTemplateResponse>;