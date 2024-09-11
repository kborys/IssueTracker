using AutoMapper;
using IssueTracker.Core.Dal.Repositories;
using IssueTracker.Core.Dto;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Exceptions;

namespace IssueTracker.Core.Services;

internal class ProjectService(IProjectRepository repository, IMapper mapper) : IProjectService
{
    public async Task AddAsync(ProjectDto dto)
    {
        dto.Id = Guid.NewGuid();
        var project = mapper.Map<Project>(dto);
        await repository.AddAsync(project);
    }

    public async Task<ProjectDetailsDto> GetAsync(Guid id)
    {
        var project = await repository.GetAsync(id)
                      ?? throw new ProjectNotFoundException(id);
        var dto = mapper.Map<ProjectDetailsDto>(project);
        return dto;
    }

    public async Task<IReadOnlyList<ProjectDto>> BrowseAsync()
    {
        var projects = await repository.BrowseAsync();
        var dto = mapper.Map<IReadOnlyList<ProjectDto>>(projects);
        return dto;
    }

    public async Task UpdateAsync(ProjectDto dto)
    {
        var project = await repository.GetAsync(dto.Id)
                      ?? throw new ProjectNotFoundException(dto.Id);
        project.Name = dto.Name;
        project.Description = dto.Description;
        await repository.UpdateAsync(project);
    }

    public async Task DeleteAsync(Guid id)
    {
        var project = await repository.GetAsync(id)
                      ?? throw new ProjectNotFoundException(id);
        await repository.DeleteAsync(project);
    }
}