namespace IssueTracker.Core.Dto;

public record ProjectDetailsDto(
    Guid Id,
    // string Key,
    string Name,
    string Description,
    DateTime CreatedAt,
    UserDto CreatedBy,
    IEnumerable<IssueDto> Issues);