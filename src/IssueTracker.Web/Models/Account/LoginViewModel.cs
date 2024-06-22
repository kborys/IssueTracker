using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Web.Models.Account;

public class LoginViewModel
{
    [Display(Name = "Email")] public string Email { get; set; }
    [Display(Name = "Hasło")] public string Password { get; set; }
    [Display(Name = "Zapamiętaj mnie")] public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; }
}