using AutoMapper;
using IssueTracker.Core.Dto;
using IssueTracker.Web.Models.Account;
using IssueTracker.Web.Models.Issue;
using IssueTracker.Web.Models.Project;

namespace IssueTracker.Web;

internal class WebProfile : Profile
{
    public WebProfile()
    {
        CreateMap<IssueDto, SimpleIssueViewModel>();

        CreateMap<IssueDetailsDto, IssueDetailsViewModel>();

        CreateMap<CreateIssueViewModel, IssueDetailsDto>();

        CreateMap<CreateProjectViewModel, ProjectDto>();

        CreateMap<ProjectDetailsDto, EditProjectViewModel>();
        CreateMap<ProjectDetailsDto, ProjectIssuesViewModel>()
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Id));

        CreateMap<ProjectDto, EditProjectViewModel>()
            .ReverseMap();

        CreateMap<RegisterViewModel, UserDto>();
    }
}