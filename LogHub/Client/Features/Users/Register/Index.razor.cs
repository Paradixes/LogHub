using System.Text.RegularExpressions;
using MudBlazor;

namespace LogHub.Client.Features.Users.Register;

public partial class Index
{
    private string[] _errors = Array.Empty<string>();

    private MudForm _form = new();

    private MudTextField<string>? _passwordField = new();

    private bool _success;

    private static IEnumerable<string> PasswordStrength(string pw)
    {
        if (string.IsNullOrWhiteSpace(pw))
        {
            yield return "Password is required!";
            yield break;
        }

        if (pw.Length < 8)
        {
            yield return "Password must be at least of length 8";
        }

        if (!Regex.IsMatch(pw, @"[A-Z]"))
        {
            yield return "Password must contain at least one capital letter";
        }

        if (!Regex.IsMatch(pw, @"[a-z]"))
        {
            yield return "Password must contain at least one lowercase letter";
        }

        if (!Regex.IsMatch(pw, @"[0-9]"))
        {
            yield return "Password must contain at least one digit";
        }
    }

    private string? PasswordMatch(string arg)
    {
        return _passwordField?.Value != arg ? "Passwords don't match" : null;
    }
}
