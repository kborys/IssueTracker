using IssueTracker.Abstractions.Exceptions;

namespace IssueTracker.Core.Exceptions;

public class UserNotFoundException(Guid id) : IssueTrackerException($"User with id: '{id}' was not found.")
{
    public Guid Id { get; set; } = id;
}