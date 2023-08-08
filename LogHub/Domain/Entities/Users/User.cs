using Domain.Entities.Behaviours.Actions;
using Domain.Entities.Behaviours.Requests;
using Domain.Entities.Middlewares;
using Domain.Entities.Organisations;
using Domain.Entities.Records;
using Domain.Entities.Records.Docs;
using Domain.Primitives;
using Shared.Enums;

namespace Domain.Entities.Users;

public class User : Entity<UserId>, IAuditableEntity
{
    private readonly List<FavouriteDoc> _favouriteDocs = new();

    private readonly List<OrganisationMembership> _organisationMemberships = new();

    private readonly List<RecordAction> _recordActions = new();

    private readonly List<RecordPermission> _recordPermissions = new();

    private readonly List<Record> _records = new();

    private readonly List<RecordRequest> _requestToHandle = new();

    private readonly List<RecordRequest> _requestToInitiate = new();

    protected User() { }

    public IEnumerable<FavouriteDoc> FavouriteDocs => _favouriteDocs.ToList();

    public IEnumerable<OrganisationMembership> OrganisationMemberships => _organisationMemberships.ToList();

    public IEnumerable<RecordPermission> RecordPermissions => _recordPermissions.ToList();

    public IEnumerable<RecordRequest> RequestToHandle => _requestToHandle.ToList();

    public IEnumerable<RecordRequest> RequestToInitiate => _requestToInitiate.ToList();

    public IEnumerable<RecordAction> RecordActions => _recordActions.ToList();

    public IEnumerable<Record> Records => _records.ToList();

    public string Name { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    // TODO: Email Verify Flag
    public bool EmailConfirmed { get; private set; } = true;

    public Uri? AvatarUri { get; private set; }

    public string Profession { get; private set; } = null!;

    public string? Orcid { get; private set; }

    public string HashedPassword { get; private set; } = null!;

    public UserRole Role { get; private set; }

    public UserPreference UserPreference { get; private set; } = null!;

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public static User Create(
        string name,
        string email,
        OrganisationId? organisationId,
        string profession,
        string? orcid,
        UserRole role)
    {
        var user = new User
        {
            Name = name,
            Email = email,
            Profession = profession,
            Orcid = orcid,
            Role = role,
            UserPreference = new UserPreference()
        };

        if (organisationId is not null)
        {
            user._organisationMemberships.Add(new OrganisationMembership(organisationId, user.Id,
                OrganisationRole.Admin));
        }

        return user;
    }

    public void UpdateProfile(
        string name,
        string profession,
        string? orcid)
    {
        Name = name;
        Profession = profession;
        Orcid = orcid;
    }

    public void UpdatePreference(
        Theme theme,
        bool emailNotification,
        bool autoSave,
        int fontSize)
    {
        UserPreference.Update(theme, emailNotification, autoSave, fontSize);
    }

    public void UpdateAvatar(Uri avatarUri)
    {
        AvatarUri = avatarUri;
    }

    public void AddOrganisationMembership(
        OrganisationId organisationId,
        OrganisationRole role)
    {
        if (_organisationMemberships.Any(x => x.OrganisationId == organisationId))
        {
            return;
        }

        _organisationMemberships.Add(new OrganisationMembership(organisationId, Id, role));
    }

    public void CreateOrganisation(
        string name,
        string? description,
        OrganisationId parentId)
    {
        if (Role != UserRole.DataManager)
        {
            throw new InvalidOperationException("Only admin can create organisation");
        }

        var organisation = Organisation.Create(Id, name, description, parentId);

        _organisationMemberships.Add(new OrganisationMembership(organisation.Id, Id, OrganisationRole.Admin));
    }

    public void ChangePassword(string hashedPassword)
    {
        HashedPassword = hashedPassword;
    }

    public void AddFavouritePage(DocumentId docId)
    {
        if (_favouriteDocs.Any(x => x.DocId == docId))
        {
            return;
        }

        _favouriteDocs.Add(new FavouriteDoc(Id, docId));
    }

    public void RemoveFavouritePage(RecordId docId)
    {
        var favouritePage = _favouriteDocs.SingleOrDefault(x => x.DocId == docId);

        if (favouritePage is null)
        {
            return;
        }

        _favouriteDocs.Remove(favouritePage);
    }
}
