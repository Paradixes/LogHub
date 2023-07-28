using FluentValidation;
using LogHub.Client.Abstracts;
using LogHub.Client.ViewModel;

namespace LogHub.Client.Validations;

public class LoginModelValidator : LogHubValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
