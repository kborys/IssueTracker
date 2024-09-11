using IssueTracker.Abstractions.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IssueTracker.Core.Exceptions;

public class IssueNotFoundException(Guid id) : IssueTrackerException($"Issue with id: '{id}' was not found.")
{
    public Guid Id { get; set; } = id;
}