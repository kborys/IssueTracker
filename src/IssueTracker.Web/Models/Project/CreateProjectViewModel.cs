using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Web.Models.Project;

public class CreateProjectViewModel
{
    [Display(Name = "Nazwa")] public string Name { get; set; }
    [Display(Name = "Opis")] public string Description { get; set; }
}