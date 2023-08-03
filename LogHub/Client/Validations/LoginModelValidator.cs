using Client.Abstracts;
using Client.ViewModel;
using FluentValidation;

namespace Client.Validations;

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