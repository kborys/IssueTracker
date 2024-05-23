namespace IssueTracker.Core.Entities;

internal class IssueComment : AuditableEntity
{
    public string Content { get; set; }
    public IssueComment? ParentComment { get; set; }
}