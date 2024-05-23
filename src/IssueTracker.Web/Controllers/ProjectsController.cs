using IssueTracker.Core.Dto;
using IssueTracker.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Web.Controllers;

public class ProjectsController(IProjectService projectService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var projects = await projectService.BrowseAsync();
        return View(projects.AsEnumerable());
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var project = await projectService.GetAsync(id);

        return View(project);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectDetailsDto project)
    {
        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Index));

        await projectService.AddAsync(project);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await projectService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPut]
    public async Task<IActionResult> Update(ProjectDetailsDto project)
    {
        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Index));

        await projectService.UpdateAsync(project);
        return RedirectToAction(nameof(Index));
    }
}