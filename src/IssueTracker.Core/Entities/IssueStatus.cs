using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Core.Entities;

public enum IssueStatus
{
    [Display(Name = "Odrzucone")] Rejected = -1,
    [Display(Name = "Nowe")] New = 0,
    [Display(Name = "W toku")] InProgress,
    [Display(Name = "Gotowe")] Completed
}