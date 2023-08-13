using Application.Organisations.GetById;
using Application.Users.GetById;
using Shared.Enums;

namespace Application.Memberships.GetSubOrganisations;

public record OrganisationMembershipResponse(
    UserResponse User,
    OrganisationResponse Organisation,
    OrganisationRole Role);