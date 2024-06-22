using Microsoft.AspNetCore.Mvc;
using IssueTracker.Core.Services;

namespace IssueTracker.Web.Views.Shared.Components;

public class ProjectsDropdownViewComponent(IProjectService projectService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var projects = await projectService.BrowseAsync();
        return View(projects);
    }
}