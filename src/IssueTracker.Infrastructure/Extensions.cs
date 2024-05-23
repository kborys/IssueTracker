using IssueTracker.Abstractions;
using IssueTracker.Infrastructure.Time;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracker.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IClock, UtcClock>();

        return services;
    }
}