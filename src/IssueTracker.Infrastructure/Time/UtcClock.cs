using IssueTracker.Abstractions;

namespace IssueTracker.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}