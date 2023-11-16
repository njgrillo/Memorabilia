namespace Memorabilia.Repository.Implementations;

public class ProjectRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<Project>(context, memoryCache), IProjectRepository
{
    private IQueryable<Project> Project 
        => Items.Include(project => project.Baseball)
                .Include(project => project.Card)
                .Include(project => project.HallOfFame)
                .Include(project => project.Helmet)
                .Include(project => project.Item)
                .Include(project => project.MemorabiliaTeams)
                .Include(project => project.People)
                .Include(project => project.Team)
                .Include(project => project.WorldSeries);

    public override async Task<Project> Get(int id)
        => await Project.SingleOrDefaultAsync(project => project.Id == id);

    public async Task<Project[]> GetAll(int userId)
        => await Project.Where(project => project.UserId == userId)
                        .ToArrayAsync();
}
