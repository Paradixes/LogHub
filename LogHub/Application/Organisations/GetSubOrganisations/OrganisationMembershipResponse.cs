using Application.Organisations.GetById;
using Application.Users.GetById;
using Shared.Enums;

namespace Application.Organisations.GetSubOrganisations;

public record OrganisationMembershipResponse(
    UserResponse User,
    OrganisationResponse Organisation,
    OrganisationRole Role);
