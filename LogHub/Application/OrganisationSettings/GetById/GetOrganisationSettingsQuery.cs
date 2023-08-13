using Domain.Entities.Organisations;
using MediatR;

namespace Application.OrganisationSettings.GetById;

public record GetOrganisationSettingsQuery(OrganisationId OrganisationId) :
    IRequest<List<OrganisationSettingResponse>>;
