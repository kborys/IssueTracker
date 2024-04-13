using FluentValidation;
using IssueTracker.Web.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Web.Controllers;

[AllowAnonymous]
public class AccountController(
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager)
    : Controller
{
    public async Task<IActionResult> Login()
    {
        // Clear the existing external cookie to ensure a clean login process
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestModel request, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
            return View(request);

        var result = await signInManager.PasswordSignInAsync(request.Email, request.Password,
            request.RememberMe, false);
        if (result.Succeeded)
            return LocalRedirect(returnUrl ?? Url.Content("~/"));

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(request);
    }

    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return LocalRedirect(Url.Content("~/"));
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequestModel request)
    {
        if (!ModelState.IsValid)
            return View(request);

        var user = new IdentityUser { UserName = request.Email, Email = request.Email };
        var result = await userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            await signInManager.SignInAsync(user, isPersistent: false);
            return View(request);
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View(request);
    }
}