using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ProjectRepository : MemorabiliaRepository<Project>, IProjectRepository
{
    public ProjectRepository(MemorabiliaContext context) : base(context) { }

    private IQueryable<Project> Project => Items.Include(project => project.People);

    public override async Task<Project> Get(int id)
    {
        return await Project.SingleOrDefaultAsync(project => project.Id == id);
    }

    public async Task<IEnumerable<Project>> GetAll(int userId)
    {
        return await Project.Where(project => project.UserId == userId).ToListAsync();
    }
}
