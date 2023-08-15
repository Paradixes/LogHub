using Application.Records.DataManagementPlanTemplates.GetById;
using Domain.Entities.Organisations;
using MediatR;

namespace Application.Records.DataManagementPlanTemplates.GetByOrganisationId;

public record GetDataManagementPlanTemplateByOrganisationIdQuery(OrganisationId OrganisationId) :
    IRequest<List<DataManagementPlanResponse>>;