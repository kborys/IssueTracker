namespace IssueTracker.Abstractions.Exceptions;

public abstract class IssueTrackerException(string message) : Exception(message);