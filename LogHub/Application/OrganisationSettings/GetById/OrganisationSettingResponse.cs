using Shared.Enums;

namespace Application.OrganisationSettings.GetById;

public record OrganisationSettingResponse(
    Guid OrganisationId,
    OrganisationRole Role,
    OrganisationOption Option);