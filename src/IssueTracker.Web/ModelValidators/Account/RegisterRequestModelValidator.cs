using FluentValidation;
using IssueTracker.Web.Models.Account;

namespace IssueTracker.Web.ModelValidators.Account;

public class RegisterRequestModelValidator : AbstractValidator<RegisterViewModel>
{
    public RegisterRequestModelValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Imię jest wymagane!")
            .MaximumLength(50)
            .WithMessage("Imię nie może być dłuższe 50 100 znaków!");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Nazwisko jest wymagane!")
            .MaximumLength(50)
            .WithMessage("Nazwisko nie może być dłuższe niż 50 znaków!");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Hasło jest wymagane!")
            .MinimumLength(8)
            .WithMessage("Hasło musi składać się z co najmniej 8 znaków!")
            .MaximumLength(100)
            .WithMessage("Hasło nie może być dłuższe niż 100 znaków!");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Potwierdzenie hasła jest wymagane!")
            .Must((model, confirmPassword) => confirmPassword == model.Password)
            .WithMessage("Hasła różnią się!");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email jest wymagany!")
            .EmailAddress()
            .WithMessage("Email nie jest poprawny!");

        RuleFor(x => x.AvatarUrl)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrWhiteSpace(x.AvatarUrl))
            .WithMessage("Niepoprawny link do avatara. Spróbuj ponownie lub pozostaw puste!");
    }
}