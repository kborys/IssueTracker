using AutoMapper;
using IssueTracker.Core.Dal.Repositories;
using IssueTracker.Core.Dto;
using IssueTracker.Core.Entities;

namespace IssueTracker.Core.Services;

internal class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public Task AddAsync(UserDto dto)
    {
        var user = mapper.Map<User>(dto);
        return userRepository.AddAsync(user);
    }
}