using IssueTracker.Core.Dal;
using IssueTracker.Core.Dal.Repositories;
using IssueTracker.Core.Services;
using IssueTracker.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracker.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services) =>
        services
            .AddAutoMapper(typeof(CoreProfile))
            .AddPostgres<CoreDbContext>()
            .AddScoped<IIssueRepository, IssueRepository>()
            .AddScoped<IIssueService, IssueService>()
            .AddScoped<IProjectRepository, ProjectRepository>()
            .AddScoped<IProjectService, ProjectService>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>();
}