using System.Security.Claims;
using AutoMapper;
using IssueTracker.Core.Dto;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Exceptions;
using IssueTracker.Core.Services;
using IssueTracker.Web.Models.Project;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Web.Controllers;

public class ProjectsController(IProjectService projectService, IMapper mapper) : Controller
{
    [HttpGet("[controller]")]
    public async Task<IActionResult> List()
    {
        var projects = await projectService.BrowseAsync();
        return View(projects.AsEnumerable());
    }

    [HttpGet("[controller]/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("[controller]/Create")]
    public async Task<IActionResult> Create(CreateProjectViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var dto = mapper.Map<ProjectDto>(model);
        dto.CreatedById = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await projectService.AddAsync(dto);

        return RedirectToAction(nameof(Issues), new { id = dto.Id });
    }

    [HttpGet("[controller]/{id:guid}/Edit")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var project = await projectService.GetAsync(id);
        var viewModel = mapper.Map<EditProjectViewModel>(project);

        return View(viewModel);
    }

    [HttpPost("[controller]/{id:guid}/Edit")]
    public async Task<IActionResult> Edit(Guid id, EditProjectViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var project = mapper.Map<ProjectDto>(model);
        project.Id = id;
        await projectService.UpdateAsync(project);

        return RedirectToAction(nameof(List));
    }

    [HttpPost("[controller]/{id:guid}/Delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await projectService.DeleteAsync(id);
        return RedirectToAction(nameof(List));
    }

    [HttpGet("[controller]/{id:guid}/Issues")]
    public async Task<IActionResult> Issues(Guid id)
    {
        try
        {
            var project = await projectService.GetAsync(id);
            var model = mapper.Map<ProjectIssuesViewModel>(project);
            return View(model);
        }
        catch (ProjectNotFoundException)
        {
            return RedirectToAction(nameof(List));
        }
    }
}