using AutoMapper;
using IssueTracker.Core.Dto;
using IssueTracker.Core.Entities;

namespace IssueTracker.Core;

internal class CoreProfile : Profile
{
    public CoreProfile()
    {
        CreateMap<Issue, IssueDto>();

        CreateMap<Issue, IssueDetailsDto>()
            .ForMember(dest => dest.CreatedByName,
                opt => opt.MapFrom(src => $"{src.CreatedBy.FirstName} {src.CreatedBy.LastName}"))
            .ForMember(dest => dest.CreatedByAvatarUrl, opt => opt.MapFrom(src => src.CreatedBy.AvatarUrl))
            .ForMember(dest => dest.AssignedToName,
                opt => opt.MapFrom(src =>
                    src.AssignedTo == null ? null : $"{src.AssignedTo.FirstName} {src.AssignedTo.LastName}"))
            .ForMember(dest => dest.AssignedToAvatarUrl,
                opt => opt.MapFrom(src => src.AssignedTo == null ? null : src.AssignedTo.AvatarUrl));

        CreateMap<IssueDetailsDto, Issue>()
            .ForMember(dest => dest.AssignedTo, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Project, opt => opt.Ignore());

        CreateMap<Project, ProjectDetailsDto>()
            .ReverseMap();
        CreateMap<Project, ProjectDto>()
            .ReverseMap();

        CreateMap<User, UserDto>()
            .ReverseMap();
    }
}