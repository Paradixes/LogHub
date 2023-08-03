using Domain.Entities.Docs;
using Domain.Entities.Organisations;
using Domain.Primitives;
using Shared.Enums;

namespace Domain.Entities.Users;

public class User : Entity<UserId>, IAuditableEntity
{
    private readonly List<FavouriteDoc> _favouriteDocs = new();

    private User() { }

    public IEnumerable<FavouriteDoc> FavouriteDocs => _favouriteDocs.ToList();

    public string Name { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    // TODO: Email Verify Flag
    // public bool EmailConfirmed { get; private set; }

    public Uri? AvatarUri { get; private set; }

    public OrganisationId? OrganisationId { get; private set; }

    public DepartmentId? DepartmentId { get; private set; }

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
        DepartmentId? departmentId,
        string profession,
        string? orcid,
        UserRole role)
    {
        var user = new User
        {
            Name = name,
            Email = email,
            OrganisationId = organisationId,
            DepartmentId = departmentId,
            Profession = profession,
            Orcid = orcid,
            Role = role,
            UserPreference = new UserPreference()
        };

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

    public void SetOrganisation(OrganisationId organisationId)
    {
        OrganisationId = organisationId;
    }

    public void SetDepartment(DepartmentId departmentId)
    {
        if (OrganisationId is null)
        {
            throw new InvalidOperationException("OrganisationId is null");
        }

        DepartmentId = departmentId;
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