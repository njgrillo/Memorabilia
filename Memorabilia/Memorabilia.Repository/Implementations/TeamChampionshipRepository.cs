namespace Memorabilia.Repository.Implementations;

public class TeamChampionshipRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<Champion>(context, memoryCache), ITeamChampionshipRepository
{
    public async Task<Champion[]> GetAll(int? teamId = null)
        => teamId.HasValue
            ? await Items.Where(champion => champion.TeamId == teamId)
                         .ToArrayAsync()
            : await Items.ToArrayAsync();
}
