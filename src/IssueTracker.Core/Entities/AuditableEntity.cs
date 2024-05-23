using System.Data.Common;

namespace IssueTracker.Core.Entities;

internal class AuditableEntity : AuditableEntity<Guid>
{
}

internal class AuditableEntity<T>
{
    public required T Id { get; init; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public required User CreatedBy { get; init; }
}