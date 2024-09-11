using System.Security.Claims;
using AutoMapper;
using IssueTracker.Core.Dto;
using IssueTracker.Core.Services;
using IssueTracker.Web.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Web.Controllers;

[AllowAnonymous]
public class AccountsController(
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager,
    IUserService userService,
    IMapper mapper)
    : Controller
{
    public async Task<IActionResult> Login()
    {
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        if (result.Succeeded)
            return LocalRedirect(returnUrl ?? Url.Content("~/"));

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(model);
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
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var identityUser = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await userManager.CreateAsync(identityUser, model.Password);
        if (result.Succeeded)
        {
            await signInManager.SignInAsync(identityUser, isPersistent: false);

            var applicationUser = mapper.Map<UserDto>(model);
            applicationUser.Id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await userService.AddAsync(applicationUser);

            return RedirectToAction("List", "Projects");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);
        return View(model);
    }
}