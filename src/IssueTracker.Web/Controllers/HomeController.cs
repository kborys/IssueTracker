using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IssueTracker.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace IssueTracker.Web.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}