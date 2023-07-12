using LogHub.Domain.DomainEvents;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.User;

public class User : Entity<UserId>
{
    // For EF Core
    private User()
    {
    }

    private User(
        UserId id,
        string name,
        string email,
        byte[]? avatar,
        string profession,
        string? orcid,
        string passwordHash,
        string salt,
        UserRole role) : base(id)
    {
        Name = name;
        Email = email;
        Avatar = avatar;
        Profession = profession;
        Orcid = orcid;
        PasswordHash = passwordHash;
        Role = role;
        Salt = salt;
    }

    public string Name { get; private set; }

    public string Email { get; private set; }

    // public bool EmailConfirmed { get; private set; }

    public byte[]? Avatar { get; private set; }

    public string Profession { get; private set; }

    public string? Orcid { get; private set; }

    public string PasswordHash { get; private set; }

    public string Salt { get; private set; }

    public UserRole Role { get; private set; }

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
            Role = role
        };

        user.Raise(new UserRegisteredEvent(Guid.NewGuid(), user.Id));

        return user;
    }

    public void ChangeName(string name)
    {
        if (name != Name) Raise(new UserNameChangedEvent(Guid.NewGuid(), Id, name));
    }
}

public record UserId(Guid Value) : EntityId(Value);
