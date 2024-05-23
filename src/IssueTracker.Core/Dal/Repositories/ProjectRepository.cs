using IssueTracker.Core.Entities;

namespace IssueTracker.Core.Dal.Repositories;

internal class ProjectRepository : IProjectRepository
{
    public Task<Project> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Project>> BrowseAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}