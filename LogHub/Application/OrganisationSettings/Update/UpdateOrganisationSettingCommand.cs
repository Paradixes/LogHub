using Domain.Entities.Organisations;
using MediatR;
using Shared.Enums;

namespace Application.OrganisationSettings.Update;

public record UpdateOrganisationSettingCommand(
    OrganisationId OrganisationId,
    OrganisationOption Option,
    OrganisationRole Role) : IRequest;
