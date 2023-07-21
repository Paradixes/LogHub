using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Users;

public class User : Entity<UserId>, IAuditableEntity
{
    private readonly List<FavouriteDoc> _favouritePages = new();

    private User() { }

    public IReadOnlyCollection<FavouriteDoc> FavouritePages => _favouritePages.ToList();

    public string Name { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    // TODO: Email Verify Flag
    // public bool EmailConfirmed { get; private set; }

    public byte[]? Avatar { get; private set; }

    public OrganisationId OrganisationId { get; private set; } = null!;

    public DepartmentId? DepartmentId { get; private set; }

    public string Profession { get; private set; } = null!;

    public string? Orcid { get; private set; }

    public string PasswordHash { get; private set; } = null!;

    public string PasswordSalt { get; private set; } = null!;

    public UserRole Role { get; private set; }

    public UserSetting UserSetting { get; private set; } = null!;

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }


    /// <summary>
    ///     Register a new User and initialise the User's settings
    /// </summary>
    /// <returns>The New User</returns>
    public static User Create(
        string name,
        string email,
        byte[]? avatar,
        OrganisationId organisationId,
        string profession,
        string? orcid,
        string passwordHash,
        string passwordSalt,
        UserRole role)
    {
        var user = new User
        {
            Name = name,
            Email = email,
            Avatar = avatar,
            OrganisationId = organisationId,
            Profession = profession,
            Orcid = orcid,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Role = role,
            UserSetting = new UserSetting()
        };

        return user;
    }

    /// <summary>
    ///     Change a current user's name
    /// </summary>
    public void UpdateProfile(
        string name,
        byte[]? avatar,
        string profession,
        string? orcid)
    {
        Name = name;
        Avatar = avatar;
        Profession = profession;
        Orcid = orcid;
    }

    public void UpdateUserSetting(
        Theme theme,
        bool emailNotification,
        bool autoSave,
        int fontSize)
    {
        UserSetting.Update(theme, emailNotification, autoSave, fontSize);
    }

    /// <summary>
    /// </summary>
    /// <param name="passwordHash"></param>
    /// <param name="salt"></param>
    public void ResetPassword(string passwordHash, string salt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = salt;
    }

    public void AddFavouritePage(RecordId docId)
    {
        if (_favouritePages.Any(x => x.DocId == docId))
        {
            return;
        }

        _favouritePages.Add(new FavouriteDoc(Id, docId));
    }

    public void RemoveFavouritePage(RecordId docId)
    {
        var favouritePage = _favouritePages.SingleOrDefault(x => x.DocId == docId);

        if (favouritePage is null)
        {
            return;
        }

        _favouritePages.Remove(favouritePage);
    }
}
