using Application.DataManagementPlanTemplates.GetById;
using Domain.Entities.Organisations;
using MediatR;

namespace Application.DataManagementPlanTemplates.GetByOrganisationId;

public record GetDataManagementPlanTemplateByOrganisationIdQuery(OrganisationId OrganisationId) :
    IRequest<List<DataManagementPlanTemplateResponse>>;
