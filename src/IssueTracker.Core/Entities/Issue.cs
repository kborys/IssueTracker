namespace IssueTracker.Core.Entities;

internal class Issue : AuditableEntity
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IssueType Type { get; set; } = IssueType.Undefined;
    public IssueStatus Status { get; set; } = IssueStatus.New;
    public IssuePriority Priority { get; set; } = IssuePriority.Unassigned;
    public User? AssignedTo { get; set; }
    public IEnumerable<Issue> SubIssues { get; set; } = Enumerable.Empty<Issue>();
    public IEnumerable<IssueComment> Comments { get; set; } = Enumerable.Empty<IssueComment>();

    // todo borysk - keep history of changes
    // todo borysk - issue content - design, desc etc
}