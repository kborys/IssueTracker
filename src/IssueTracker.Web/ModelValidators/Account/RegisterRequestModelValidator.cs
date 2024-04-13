using FluentValidation;
using IssueTracker.Web.Models.Account;

namespace IssueTracker.Web.ModelValidators.Account;

public class RegisterRequestModelValidator : AbstractValidator<RegisterRequestModel>
{
    public RegisterRequestModelValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long")
            .MaximumLength(100)
            .WithMessage("Password must be at most 100 characters long");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Password confirmation is required")
            .Must((model, confirmPassword) => confirmPassword == model.Password)
            .WithMessage("Passwords do not match");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not a valid email address");
    }
}