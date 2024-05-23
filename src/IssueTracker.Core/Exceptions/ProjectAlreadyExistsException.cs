using IssueTracker.Abstractions.Exceptions;

namespace IssueTracker.Core.Exceptions;

public class ProjectAlreadyExistsException(
    Guid id) : IssueTrackerException($"Project with id: '{id}' already exists.")
{
    public Guid Id { get; set; } = id;
}