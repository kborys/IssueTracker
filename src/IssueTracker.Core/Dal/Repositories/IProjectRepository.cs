using IssueTracker.Core.Entities;

namespace IssueTracker.Core.Dal.Repositories;

internal interface IProjectRepository
{
    Task<Project?> GetAsync(Guid id);
    Task<IReadOnlyList<Project>> BrowseAsync();
    Task AddAsync(Project project);
    Task UpdateAsync(Project project);
    Task DeleteAsync(Project project);
    Task<bool> ExistsAsync(Guid id);
}