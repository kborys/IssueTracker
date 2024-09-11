namespace IssueTracker.Core.Dto;

public class ProjectDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CreatedById { get; set; }
    public IEnumerable<IssueDto> Issues { get; set; } = new List<IssueDto>();
}