using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Web.Controllers;

public class ProjectController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}