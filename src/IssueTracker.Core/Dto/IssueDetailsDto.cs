using IssueTracker.Core.Entities;

namespace IssueTracker.Core.Dto;

public class IssueDetailsDto
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public IssueType Type { get; set; }
    public IssuePriority Priority { get; set; }
    public IssueStatus Status { get; set; }
    public Guid CreatedById { get; set; }
    public string CreatedByName { get; set; }
    public string CreatedByAvatarUrl { get; set; }
    public Guid? AssignedToId { get; set; }
    public string AssignedToName { get; set; }
    public string AssignedToAvatarUrl { get; set; }
    public Guid ProjectId { get; set; }
}