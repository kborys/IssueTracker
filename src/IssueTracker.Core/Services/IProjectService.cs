using IssueTracker.Core.Dto;

namespace IssueTracker.Core.Services;

public interface IProjectService
{
    Task AddAsync(ProjectDetailsDto dto);
    Task<ProjectDetailsDto> GetAsync(Guid id);
    Task<IReadOnlyList<ProjectDto>> BrowseAsync();
    Task UpdateAsync(ProjectDetailsDto dto);
    Task DeleteAsync(Guid id);
}