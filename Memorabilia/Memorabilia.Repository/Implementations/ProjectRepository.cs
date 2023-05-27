using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ProjectRepository : MemorabiliaRepository<Project>, IProjectRepository
{
    public ProjectRepository(MemorabiliaContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Project> Project => Items.Include(project => project.Baseball)
                                                .Include(project => project.Card)
                                                .Include(project => project.HallOfFame)
                                                .Include(project => project.Helmet)
                                                .Include(project => project.Item)
                                                .Include(project => project.MemorabiliaTeams)
                                                .Include(project => project.People)
                                                .Include(project => project.Team)
                                                .Include(project => project.WorldSeries);

    public override async Task<Project> Get(int id)
    {
        return await Project.SingleOrDefaultAsync(project => project.Id == id);
    }

    public async Task<IEnumerable<Project>> GetAll(int userId)
    {
        return await Project.Where(project => project.UserId == userId).ToListAsync();
    }
}
