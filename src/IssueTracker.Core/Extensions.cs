using IssueTracker.Core.Dal;
using IssueTracker.Core.Dal.Repositories;
using IssueTracker.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracker.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        services.AddDbContext<ApplicationDbContext>(opts =>
        {
            opts.UseSqlite(configuration.GetConnectionString("Application"));
        });

        services
            .AddScoped<IProjectService, ProjectService>()
            // .AddScoped<IProjectRepository, InMemoryProjectRepository>()
            .AddSingleton<IProjectRepository, InMemoryProjectRepository>()
            .AddAutoMapper(typeof(CoreProfile));

        return services;
    }
}