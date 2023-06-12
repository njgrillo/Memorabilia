namespace Memorabilia.Repository.Implementations;

public class TeamChampionshipRepository 
    : DomainRepository<Entity.Champion>, ITeamChampionshipRepository
{
    public TeamChampionshipRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<Entity.Champion[]> GetAll(int? teamId = null)
        => teamId.HasValue
            ? await Items.Where(champion => champion.TeamId == teamId)
                         .ToArrayAsync()
            : await Items.ToArrayAsync();
}
