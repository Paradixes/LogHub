namespace Domain.Exceptions.Users;

public sealed class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException() : base("Invalid credentials") { }
}
