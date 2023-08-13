using Shared.Enums;

namespace Client.ViewModel;

public class OrganisationSettingsModel
{
    public OrganisationSettingsModel(
        Guid organisationId,
        OrganisationOption option,
        OrganisationRole role)
    {
        OrganisationId = organisationId;
        Option = option;
        Role = role;
    }

    public Guid OrganisationId { get; set; }

    public OrganisationOption Option { get; set; }

    public OrganisationRole Role { get; set; }
}
