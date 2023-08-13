using Domain.Entities.Middlewares;
using Domain.Entities.Records;
using Domain.Entities.Records.DataManagementPlans;
using Domain.Entities.Records.Repositories;
using Domain.Entities.Users;
using Domain.Primitives;
using Shared.Enums;

namespace Domain.Entities.Organisations;

public class Organisation : Entity<OrganisationId>
{
    private readonly List<DataManagementPlanTemplate> _dataManagementPlanTemplates = new();

    private readonly List<OrganisationMembership> _memberships = new();

    private readonly List<Repository> _repositories = new();

    private readonly List<OrganisationSetting> _settings = new();

    private readonly List<Organisation> _subOrganisations = new();

    private Organisation() { }

    public IEnumerable<Organisation> SubOrganisations => _subOrganisations.ToList();

    public IEnumerable<DataManagementPlanTemplate> DataManagementPlanTemplates => _dataManagementPlanTemplates.ToList();

    public IEnumerable<Repository> Repositories => _repositories.ToList();

    public IEnumerable<OrganisationMembership> Memberships => _memberships.ToList();

    public IEnumerable<OrganisationSetting> Settings => _settings.ToList();

    public OrganisationId? ParentOrganisationId { get; private set; }

    public Organisation? ParentOrganisation { get; private set; }

    public OrganisationId? RootOrganisationId { get; private set; }

    public Organisation? RootOrganisation { get; private set; }

    public string InvitationCode { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public Uri? LogoUri { get; private set; }

    public string? Description { get; private set; }

    private static string GenerateRandomString(int length)
    {
        var random = new Random();
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(characters, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static Organisation Create(
        UserId creatorId,
        string name,
        string? description,
        OrganisationId? parentOrganisationId)
    {
        var organisation = new Organisation
        {
            Name = name,
            Description = description,
            InvitationCode = GenerateRandomString(8),
            ParentOrganisationId = parentOrganisationId
        };

        organisation._memberships.Add(new OrganisationMembership(organisation.Id, creatorId, OrganisationRole.Owner));

        foreach (var option in Enum.GetValues<OrganisationOption>())
        {
            organisation._settings.Add(new OrganisationSetting(organisation.Id, option, OrganisationRole.Owner));
        }

        if (parentOrganisationId is null)
        {
            organisation.RootOrganisationId = organisation.Id;
        }

        return organisation;
    }

    public void UpdateInvitationCode()
    {
        InvitationCode = GenerateRandomString(8);
    }

    public Organisation AddSubOrganisation(
        UserId creatorId,
        string name,
        string? description)
    {
        var organisation = Create(creatorId, name, description, Id);
        _subOrganisations.Add(organisation);

        organisation.RootOrganisationId = RootOrganisationId ?? Id;

        return organisation;
    }

    public void RemoveSubOrganisation(OrganisationId childOrganisationId)
    {
        var organisation = _subOrganisations.SingleOrDefault(x => x.Id == childOrganisationId);
        if (organisation is null)
        {
            return;
        }

        _subOrganisations.Remove(organisation);
    }

    public void AddDataManagementPlanTemplate(
        UserId creatorId,
        string title,
        string icon,
        string? description)
    {
        var dataManagementPlanTemplate = DataManagementPlanTemplate.Create(Id, creatorId, title, icon, description);
        _dataManagementPlanTemplates.Add(dataManagementPlanTemplate);
    }

    public void RemoveDataManagementPlanTemplate(RecordId recordId)
    {
        var dataManagementPlan = _dataManagementPlanTemplates.SingleOrDefault(x => x.Id == recordId);
        if (dataManagementPlan is null)
        {
            return;
        }

        _dataManagementPlanTemplates.Remove(dataManagementPlan);
    }

    public void UpdateDetails(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public void SetLogo(Uri? logoUri)
    {
        LogoUri = logoUri;
    }

    public void AddMembership(UserId managerId, OrganisationRole role)
    {
        if (_memberships.Any(x => x.UserId == managerId))
        {
            return;
        }

        _memberships.Add(new OrganisationMembership(Id, managerId, role));
    }

    public void UpdateMembership(UserId? userId, OrganisationRole role)
    {
        if (userId is null)
        {
            return;
        }

        if (role == OrganisationRole.Owner)
        {
            _memberships.ForEach(x =>
            {
                if (x.Role == OrganisationRole.Owner)
                {
                    x.UpdateRole(OrganisationRole.Admin);
                }
            });
        }

        var membership = _memberships.SingleOrDefault(x => x.UserId == userId);

        if (membership is null)
        {
            AddMembership(userId, role);
            return;
        }

        membership.UpdateRole(role);
    }

    public void RemoveMembership(UserId managerId)
    {
        var membership = _memberships.SingleOrDefault(x => x.UserId == managerId);
        if (membership is null)
        {
            return;
        }

        _memberships.Remove(membership);
    }

    public void UpdateSetting(OrganisationOption option, OrganisationRole role)
    {
        var setting = _settings.SingleOrDefault(x => x.Option == option);
        if (setting is null)
        {
            _settings.Add(new OrganisationSetting(Id, option, role));
            return;
        }

        setting.UpdateRole(role);
    }
}
