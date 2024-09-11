using IssueTracker.Core.Dto;

namespace IssueTracker.Core.Services;

public interface IProjectService
{
    Task AddAsync(ProjectDto dto);
    Task<ProjectDetailsDto> GetAsync(Guid id);
    Task<IReadOnlyList<ProjectDto>> BrowseAsync();
    Task UpdateAsync(ProjectDto dto);
    Task DeleteAsync(Guid id);
}