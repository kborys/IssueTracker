using IssueTracker.Core.Dto;

namespace IssueTracker.Core.Services;

public interface IUserService
{
    Task AddAsync(UserDto dto);
}