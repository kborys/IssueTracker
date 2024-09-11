using AutoMapper;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Services;
using IssueTracker.Web.Models.Project;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Web.Views.Shared.Components;

public class IssueDetailsViewComponent(IIssueService issueService, IMapper mapper) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(Guid issueId)
    {
        var issue = await issueService.GetAsync(issueId);
        var model = mapper.Map<IssueDetailsViewModel>(issue);
        return View(model);
    }
}