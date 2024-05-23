namespace IssueTracker.Core.Entities;

internal class Project : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Issue> Issues { get; set; } = Enumerable.Empty<Issue>();
}