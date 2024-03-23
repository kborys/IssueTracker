using IssueTracker.Web.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Web.Controllers;

[AllowAnonymous]
public class AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    : Controller
{
    public async Task<IActionResult> Login()
    {
        // Clear the existing external cookie to ensure a clean login process
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestModel requestModel, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
            return View(requestModel);

        var result = await signInManager.PasswordSignInAsync(requestModel.Email, requestModel.Password,
            requestModel.RememberMe, false);
        if (result.Succeeded)
            return LocalRedirect(returnUrl ?? Url.Content("~/"));

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(requestModel);
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
    public async Task<IActionResult> Register(RegisterRequestModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            await signInManager.SignInAsync(user, isPersistent: false);
            return View(model);
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View(model);
    }
}