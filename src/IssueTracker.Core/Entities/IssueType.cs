using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Core.Entities;

public enum IssueType
{
    [Display(Name = "Brak")] None,
    [Display(Name = "Błąd")] Bug,
    [Display(Name = "Historia")] UserStory,
    [Display(Name = "Epika")] Epic
}