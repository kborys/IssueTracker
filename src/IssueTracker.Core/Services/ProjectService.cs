using AutoMapper;
using IssueTracker.Core.Dal.Repositories;
using IssueTracker.Core.Dto;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Exceptions;

namespace IssueTracker.Core.Services;

internal class ProjectService(IProjectRepository repository, IMapper mapper) : IProjectService
{
    public async Task AddAsync(ProjectDetailsDto dto)
    {
        if (await repository.ExistsAsync(dto.Id))
            throw new ProjectAlreadyExistsException(dto.Id);

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

    public async Task UpdateAsync(ProjectDetailsDto dto)
    {
        if (await repository.ExistsAsync(dto.Id))
            throw new ProjectAlreadyExistsException(dto.Id);

        var project = mapper.Map<Project>(dto);
        await repository.UpdateAsync(project);
    }

    public async Task DeleteAsync(Guid id)
    {
        var project = await repository.GetAsync(id)
                      ?? throw new ProjectNotFoundException(id);
        await repository.DeleteAsync(project);
    }
}