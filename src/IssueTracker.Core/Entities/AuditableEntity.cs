namespace IssueTracker.Core.Entities;

internal class AuditableEntity : AuditableEntity<Guid>
{
}

internal class AuditableEntity<T>
{
    public T Id { get; init; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public User CreatedBy { get; set; }
    public Guid CreatedById { get; set; }
}