using FluentValidation;
using LogHub.Client.Abstracts;
using LogHub.Client.ViewModel;

namespace LogHub.Client.Validations;

public class RegisterModelValidator : LogHubValidator<RegisterModel>
{
    public RegisterModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least of length 8")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one capital letter")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Role is required");

        RuleFor(x => x.Profession)
            .NotEmpty().WithMessage("Profession is required");

        RuleFor(x => x.Orcid)
            .Length(19)
            .When(x => !string.IsNullOrEmpty(x.Orcid))
            .WithMessage("ORCID must be of length 19")
            .Matches(@"\d{4}-\d{4}-\d{4}-\d{3}[0-9X]")
            .When(x => !string.IsNullOrEmpty(x.Orcid))
            .WithMessage("ORCID must be in the format XXXX-XXXX-XXXX-XXXX");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password is required")
            .Equal(x => x.Password).WithMessage("Passwords don't match");
    }
}
