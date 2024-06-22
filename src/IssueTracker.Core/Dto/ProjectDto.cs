using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Core.Dto;

public class ProjectDto
{
    public Guid Id { get; set; }
    [Display(Name = "Nazwa")] public string Name { get; set; }
    [Display(Name = "Opis")] public string Description { get; set; }
    public Guid CreatedById { get; set; }
    [Display(Name = "Twórca")] public UserDto CreatedBy { get; set; }
}