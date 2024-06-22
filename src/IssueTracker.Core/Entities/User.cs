namespace IssueTracker.Core.Entities;

internal class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? AvatarUrl { get; set; }

    public IReadOnlyList<Issue> Issues { get; set; } = new List<Issue>();
    public IReadOnlyList<Project> Projects { get; set; } = new List<Project>();
    public IReadOnlyList<IssueComment> IssueComments { get; set; } = new List<IssueComment>();
}