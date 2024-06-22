namespace IssueTracker.Core.Entities;

internal class Issue : AuditableEntity
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IssueType Type { get; set; } = IssueType.None;
    public IssueStatus Status { get; set; } = IssueStatus.New;
    public IssuePriority Priority { get; set; } = IssuePriority.None;
    public Guid? AssignedToId { get; set; }
    public User? AssignedTo { get; set; }
    public IReadOnlyList<Issue> SubIssues { get; set; } = new List<Issue>();
    public IReadOnlyList<IssueComment> Comments { get; set; } = new List<IssueComment>();

    // todo borysk - keep history of changes
}