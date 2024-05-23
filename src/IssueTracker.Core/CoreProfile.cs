using AutoMapper;
using IssueTracker.Core.Dto;
using IssueTracker.Core.Entities;

namespace IssueTracker.Core;

internal class CoreProfile : Profile
{
    public CoreProfile()
    {
        CreateMap<Issue, IssueDto>();

        CreateMap<Project, ProjectDetailsDto>()
            .ReverseMap();
        CreateMap<Project, ProjectDto>();

        CreateMap<User, UserDto>();
    }
}