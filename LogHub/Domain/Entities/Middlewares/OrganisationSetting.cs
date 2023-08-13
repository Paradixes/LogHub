using Domain.Entities.Organisations;
using Shared.Enums;

namespace Domain.Entities.Middlewares;

public class OrganisationSetting
{
    private OrganisationSetting() { }

    internal OrganisationSetting(
        OrganisationId organisationId,
        OrganisationOption option,
        OrganisationRole role)
    {
        OrganisationId = organisationId;
        Option = option;
        Role = role;
    }

    public OrganisationId OrganisationId { get; private set; } = null!;

    public Organisation? Organisation { get; private set; }

    public OrganisationOption Option { get; private set; }

    public OrganisationRole Role { get; private set; }

    public void UpdateRole(OrganisationRole role)
    {
        Role = role;
    }
}
