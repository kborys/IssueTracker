using IssueTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Core.Dal.Repositories;

internal interface IUserRepository
{
    Task<User?> GetAsync(Guid id);
    Task AddAsync(User user);
}

internal class UserRepository(CoreDbContext dbContext) : IUserRepository
{
    public Task<User?> GetAsync(Guid id) => dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(User user)
    {
        await dbContext.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }
}