using IssueTracker.Core.Entities;
using IssueTracker.Core.Exceptions;

namespace IssueTracker.Core.Dal.Repositories;

internal class InMemoryProjectRepository : IProjectRepository
{
    private readonly List<Project> _projects =
    [
        new Project
        {
            Id = Guid.NewGuid(),
            CreatedBy = new User
            {
                Id = Guid.NewGuid(),
                UserName = "John Doe"
            },
            Name = "Mock It",
            Description = "Some test project description just to mock it",
            Issues =
            [
                new Issue
                {
                    Id = Guid.NewGuid(),
                    Name = "XYZ not working properly",
                    Description = "Some test issue description just to mock it",
                    Type = IssueType.Bug,
                    CreatedBy = new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = "John Doe"
                    }
                },
                new Issue
                {
                    Id = Guid.NewGuid(),
                    Name = "Creating an issue",
                    Description =
                        "User story description user story description user story description user story description user story description user story description user story description",
                    Type = IssueType.UserStory,
                    CreatedBy = new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = "John Doe"
                    }
                }
            ]
        },
        new Project
        {
            Id = Guid.NewGuid(),
            CreatedBy = new User
            {
                Id = Guid.NewGuid(),
                UserName = "Ann Doe"
            },
            Name = "Test It",
            Description = "The project is about testing the application"
        }
    ];

    public Task<Project?> GetAsync(Guid id)
    {
        return Task.FromResult(_projects.FirstOrDefault(x => x.Id == id));
    }

    public Task<IReadOnlyList<Project>> BrowseAsync()
    {
        return Task.FromResult<IReadOnlyList<Project>>(_projects);
    }

    public Task AddAsync(Project project)
    {
        _projects.Add(project);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Project project)
    {
        var existing = _projects.FirstOrDefault(x => x.Id == project.Id);
        if (existing is null) return Task.CompletedTask;

        existing = project;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Project project)
    {
        var existing = _projects.FirstOrDefault(x => x.Id == project.Id);
        _projects.Remove(existing);
        return Task.CompletedTask;
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return Task.FromResult(_projects.Any(x => x.Id == id));
    }
}