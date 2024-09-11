namespace IssueTracker.Core.Entities;

internal class Project : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IReadOnlyList<Issue> Issues { get; set; } = new List<Issue>();
}