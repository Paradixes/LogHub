using LogHub.Domain.DomainEvents.User;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.User;

public class User : Entity<UserId>, IAuditableEntity
{
    // For EF Core
    private User() { }

    public string Name { get; private set; }

    public string Email { get; private set; }

    // public bool EmailConfirmed { get; private set; }

    public byte[]? Avatar { get; private set; }

    public string Profession { get; private set; }

    public string? Orcid { get; private set; }

    public string PasswordHash { get; private set; }

    public string Salt { get; private set; }

    public UserRole Role { get; private set; }

    public UserSetting UserSetting { get; private set; }

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
        string profession,
        string? orcid,
        string passwordHash,
        string salt,
        UserRole role)
    {
        var user = new User
        {
            Id = new UserId(Guid.NewGuid()),
            Name = name,
            Email = email,
            Avatar = avatar,
            Profession = profession,
            Orcid = orcid,
            PasswordHash = passwordHash,
            Salt = salt,
            Role = role,
            UserSetting = new UserSetting()
        };

        user.Raise(new UserRegisteredDomainEvent(Guid.NewGuid(), user.Id));

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
        if (name != Name
            || avatar != Avatar
            || profession != Profession
            || orcid != Orcid)
        {
            Raise(new UserNameChangedDomainEvent(Guid.NewGuid(), Id, name));
        }

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
        if (UserSetting.Theme != theme
            || UserSetting.EmailNotification != emailNotification
            || UserSetting.AutoSave != autoSave
            || UserSetting.FontSize != fontSize)
        {
            Raise(new UserSettingUpdatedDomainEvent(Guid.NewGuid(), Id));
        }

        UserSetting.Update(theme, emailNotification, autoSave, fontSize);
    }

    /// <summary>
    /// </summary>
    /// <param name="passwordHash"></param>
    /// <param name="salt"></param>
    public void ResetPassword(string passwordHash, string salt)
    {
        PasswordHash = passwordHash;
        Salt = salt;
    }
}