using IssueTracker.Core.Entities;

namespace IssueTracker.Core.Dal.Repositories;

internal interface IIssueRepository
{
    Task<IEnumerable<Issue>> BrowseAsync();
    Task<Issue?> GetAsync(Guid id);
    Task AddAsync(Issue issue);
    Task UpdateAsync(Issue issue);
    Task DeleteAsync(Issue issue);
    Task<bool> ExistsAsync(Issue issue);
}