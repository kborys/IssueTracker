﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IssueTracker.Infrastructure.Services;

/// <summary>
/// Service responsible for applying EFCore migrations on startup if changes detected
/// </summary>
public class AppInitializer(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(DbContext).IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext))
            .ToList();

        using var scope = serviceProvider.CreateScope();
        foreach (var dbContextType in dbContextTypes)
        {
            if (scope.ServiceProvider.GetService(dbContextType) is not DbContext dbContext)
                continue;
            await dbContext.Database?.MigrateAsync(cancellationToken)!;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}