using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Web.Models.Account;

public class RegisterRequestModel
{
    public string Email { get; init; }
    public string Password { get; init; }
    public string ConfirmPassword { get; init; }
}