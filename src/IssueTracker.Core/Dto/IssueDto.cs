using IssueTracker.Core.Entities;

namespace IssueTracker.Core.Dto;

public class IssueDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IssueType Type { get; set; }
}