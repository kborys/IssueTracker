using IssueTracker.Core.Dto;

namespace IssueTracker.Core.Services;

public interface IIssueService
{
    Task<IEnumerable<IssueDto>> BrowseAsync();
    Task<IssueDetailsDto> GetAsync(Guid id);
    Task AddAsync(IssueDetailsDto issue);
    Task UpdateAsync(IssueDetailsDto issue);
    Task DeleteAsync(Guid id);
}