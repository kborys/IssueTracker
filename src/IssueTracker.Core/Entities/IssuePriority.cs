using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Core.Entities;

public enum IssuePriority
{
    [Display(Name = "Brak")] None,
    [Display(Name = "Niski")] Low,
    [Display(Name = "Średni")] Medium,
    [Display(Name = "Wysoki")] High
}