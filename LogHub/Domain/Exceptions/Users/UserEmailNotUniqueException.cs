namespace Domain.Exceptions.Users;

public class UserEmailNotUniqueException : Exception
{
    public UserEmailNotUniqueException(string email) : base($"User with email {email} already exists") { }
}
