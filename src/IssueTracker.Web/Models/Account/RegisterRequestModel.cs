using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Web.Models.Account;

public class RegisterRequestModel
{
    public string Email { get; init; }
    public string Password { get; init; }
    [Display(Name = "Confirm Password")] public string ConfirmPassword { get; init; }
}