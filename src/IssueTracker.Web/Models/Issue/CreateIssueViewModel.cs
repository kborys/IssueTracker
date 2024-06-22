using System.ComponentModel.DataAnnotations;
using IssueTracker.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IssueTracker.Web.Models.Issue;

public class CreateIssueViewModel
{
    [Display(Name = "Nazwa")] public string Name { get; set; }
    [Display(Name = "Opis")] public string Description { get; set; }
    [Display(Name = "Typ")] public IssueType Type { get; set; }
    [Display(Name = "Priorytet")] public IssuePriority Priority { get; set; }
    [Display(Name = "Projekt")] public Guid ProjectId { get; set; }
    public List<SelectListItem> ProjectsSelectList { get; set; }
}