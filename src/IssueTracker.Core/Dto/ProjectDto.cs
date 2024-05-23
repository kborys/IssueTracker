namespace IssueTracker.Core.Dto;

public record ProjectDto(
    Guid Id,
    string Name,
    string Description);