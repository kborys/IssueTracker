using IssueTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Core.Dal.Repositories
{
    internal class IssueRepository(CoreDbContext dbContext) : IIssueRepository
    {
        public Task<Issue?> GetAsync(Guid id) =>
            dbContext.Issues
                .Include(x => x.Project)
                .Include(x => x.CreatedBy)
                .Include(x => x.AssignedTo)
                // .Include(x => x.SubIssues) // todo borysk - zaimplementować
                // .Include(x => x.Comments)
                .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Issue>> BrowseAsync() => await dbContext.Issues.ToListAsync();

        public async Task AddAsync(Issue issue)
        {
            await dbContext.Issues.AddAsync(issue);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Issue issue)
        {
            dbContext.Issues.Update(issue);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Issue issue)
        {
            dbContext.Issues.Remove(issue);
            await dbContext.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(Issue issue) => dbContext.Issues.AnyAsync(x => x.Id == issue.Id);
    }
}