using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Web.Models.Account;

public class LoginRequestModel
{
    public string Email { get; init; }
    public string Password { get; init; }
    [Display(Name = "Remember me?")] public bool RememberMe { get; init; }
    public string? ReturnUrl { get; init; }
}