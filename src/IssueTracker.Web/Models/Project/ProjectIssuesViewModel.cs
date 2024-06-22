using System.ComponentModel.DataAnnotations;
using IssueTracker.Core.Entities;

namespace IssueTracker.Web.Models.Project;

public class ProjectIssuesViewModel
{
    public Guid ProjectId { get; set; }
    public string ProjectName { get; set; }
    public List<SimpleIssueViewModel> Issues { get; set; } = [];
}

public class SimpleIssueViewModel
{
    public Guid Id { get; set; }
    [Display(Name = "Nazwa")] public string Name { get; set; }
    [Display(Name = "Typ")] public IssueType Type { get; set; }
    [Display(Name = "Przypisany")] public string? AssignedToAvatarUrl { get; set; }
    [Display(Name = "Przypisany")] public string? AssignedToInitials { get; set; }
}

public class IssueDetailsViewModel
{
    public Guid Id { get; set; }
    [Display(Name = "Nazwa")] public string Name { get; set; }
    [Display(Name = "Opis")] public string? Description { get; set; }
    [Display(Name = "Typ")] public IssueType Type { get; set; }
    [Display(Name = "Priorytet")] public IssuePriority Priority { get; set; }
    [Display(Name = "Status")] public IssueStatus Status { get; set; }
    [Display(Name = "Przypisany")] public string? AssignedToName { get; set; }
    [Display(Name = "Przypisany")] public string? AssignedToAvatarUrl { get; set; }
    [Display(Name = "Utworzył")] public string CreatedByName { get; set; }
    [Display(Name = "Utworzył")] public string? CreatedByAvatarUrl { get; set; }
    [Display(Name = "Komentarze")] public List<IssueCommentViewModel> Comments { get; set; } = [];
}

public class IssueCommentViewModel
{
    [Display(Name = "Utworzył")] public string CreatedByName { get; set; }
    [Display(Name = "Utworzył")] public string? CreatedByAvatarUrl { get; set; }
    [Display(Name = "Utworzono")] public DateTime CreatedAt { get; set; }
    [Display(Name = "Treść")] public string Content { get; set; }
}