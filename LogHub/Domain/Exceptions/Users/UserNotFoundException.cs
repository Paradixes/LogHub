using Domain.Entities.Users;

namespace Domain.Exceptions.Users;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException(UserId id)
        : base($"The user with the ID = {id.Value} was not found") { }

    public UserNotFoundException(string email)
        : base($"The user with the email = {email} was not found") { }
}
