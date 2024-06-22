using System.Security.Claims;
using AutoMapper;
using IssueTracker.Core.Dto;
using IssueTracker.Core.Services;
using IssueTracker.Web.Models.Issue;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IssueTracker.Web.Controllers;

public class IssuesController(IProjectService projectService, IIssueService issueService, IMapper mapper) : Controller
{
    [HttpGet("[controller]/{id:guid}")]
    public IActionResult Index(Guid id)
    {
        return ViewComponent("IssueDetails", id);
    }

    public async Task<IActionResult> Create()
    {
        var projects = await projectService.BrowseAsync();
        var viewModel = new CreateIssueViewModel
        {
            ProjectsSelectList = projects.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList()
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateIssueViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var dto = mapper.Map<IssueDetailsDto>(viewModel);
        dto.CreatedById = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await issueService.AddAsync(dto);

        return RedirectToAction("Issues", "Projects", new { Id = viewModel.ProjectId });
    }


    [HttpPost("[controller]/{id:guid}/Delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await issueService.DeleteAsync(id);
        return NoContent();
    }
}