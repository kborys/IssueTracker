using AutoMapper;
using IssueTracker.Core.Dal.Repositories;
using IssueTracker.Core.Dto;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Exceptions;

namespace IssueTracker.Core.Services;

internal class IssueService(
    IIssueRepository issueRepository,
    IUserRepository userRepository,
    IProjectRepository projectRepository,
    IMapper mapper)
    : IIssueService
{
    public async Task<IEnumerable<IssueDto>> BrowseAsync()
    {
        var issues = await issueRepository.BrowseAsync();
        return mapper.Map<IEnumerable<IssueDto>>(issues);
    }

    public async Task<IssueDetailsDto> GetAsync(Guid id)
    {
        var issue = await issueRepository.GetAsync(id)
                    ?? throw new IssueNotFoundException(id);
        return mapper.Map<IssueDetailsDto>(issue);
    }

    public async Task AddAsync(IssueDetailsDto dto)
    {
        var issue = mapper.Map<Issue>(dto);
        issue.CreatedBy = await userRepository.GetAsync(dto.CreatedById)
                          ?? throw new UserNotFoundException(dto.CreatedById);
        issue.Project = await projectRepository.GetAsync(dto.ProjectId)
                        ?? throw new ProjectNotFoundException(dto.ProjectId);
        await issueRepository.AddAsync(issue);
    }

    public async Task UpdateAsync(IssueDetailsDto dto)
    {
        var issue = await issueRepository.GetAsync(dto.Id)
                    ?? throw new IssueNotFoundException(dto.Id);

        issue.Name = dto.Name;
        issue.Description = dto.Description;
        issue.Priority = dto.Priority;
        issue.Status = dto.Status;
        await issueRepository.UpdateAsync(issue);
    }

    public async Task DeleteAsync(Guid id)
    {
        var issue = await issueRepository.GetAsync(id)
                    ?? throw new IssueNotFoundException(id);
        await issueRepository.DeleteAsync(issue);
    }
}