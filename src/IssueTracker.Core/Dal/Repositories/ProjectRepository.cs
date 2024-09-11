using IssueTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Core.Dal.Repositories;

internal class ProjectRepository(CoreDbContext dbContext) : IProjectRepository
{
    public async Task<Project?> GetAsync(Guid id)
    {
        var x = await dbContext.Projects.Include(x => x.Issues)
            .SingleOrDefaultAsync(x => x.Id == id);
        return x;
    }

    public async Task<IReadOnlyList<Project>> BrowseAsync()
        => await dbContext.Projects.Include(x => x.CreatedBy).ToListAsync();

    public async Task AddAsync(Project project)
    {
        await dbContext.Projects.AddAsync(project);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Project project)
    {
        dbContext.Projects.Update(project);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Project project)
    {
        dbContext.Projects.Remove(project);
        await dbContext.SaveChangesAsync();
    }

    public Task<bool> ExistsAsync(Guid id) => dbContext.Projects.AnyAsync(x => x.Id == id);
}