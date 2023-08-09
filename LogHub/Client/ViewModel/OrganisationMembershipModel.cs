using Shared.Enums;

namespace Client.ViewModel;

public class OrganisationMembershipModel
{
    public OrganisationModel Organisation { get; set; } = new();

    public UserAccountModel User { get; set; } = new();

    public OrganisationRole Role { get; set; }
}