using Shared.Enums;

namespace Application.OrganisationSettings.Update;

public record UpdateOrganisationSettingRequest(
    OrganisationOption Option,
    OrganisationRole Role);
