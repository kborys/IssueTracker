using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Web.Models.Account;

public class RegisterViewModel
{
    [Display(Name = "Imię")] public string FirstName { get; set; }
    [Display(Name = "Nazwisko")] public string LastName { get; set; }
    [Display(Name = "Email")] public string Email { get; set; }
    [Display(Name = "Hasło")] public string Password { get; set; }
    [Display(Name = "Potwierdź hasło")] public string ConfirmPassword { get; set; }
    [Display(Name = "Link do avatara")] public string? AvatarUrl { get; set; }
}