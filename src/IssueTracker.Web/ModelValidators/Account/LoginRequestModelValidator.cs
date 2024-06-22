using FluentValidation;
using IssueTracker.Web.Models.Account;

namespace IssueTracker.Web.ModelValidators.Account;

public class LoginRequestModelValidator : AbstractValidator<LoginViewModel>
{
    public LoginRequestModelValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Hasło jest wymagane!");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email jest wymagany!")
            .EmailAddress()
            .WithMessage("Email nie jest poprawny!");
    }
}