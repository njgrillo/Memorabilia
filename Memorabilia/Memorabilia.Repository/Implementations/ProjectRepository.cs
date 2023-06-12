namespace Memorabilia.Repository.Implementations;

public class ProjectRepository 
    : MemorabiliaRepository<Entity.Project>, IProjectRepository
{
    public ProjectRepository(MemorabiliaContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.Project> Project 
        => Items.Include(project => project.Baseball)
                .Include(project => project.Card)
                .Include(project => project.HallOfFame)
                .Include(project => project.Helmet)
                .Include(project => project.Item)
                .Include(project => project.MemorabiliaTeams)
                .Include(project => project.People)
                .Include(project => project.Team)
                .Include(project => project.WorldSeries);

    public override async Task<Entity.Project> Get(int id)
        => await Project.SingleOrDefaultAsync(project => project.Id == id);

    public async Task<Entity.Project[]> GetAll(int userId)
        => await Project.Where(project => project.UserId == userId)
                        .ToArrayAsync();
}
