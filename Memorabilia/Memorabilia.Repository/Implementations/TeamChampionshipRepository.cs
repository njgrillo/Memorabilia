using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class TeamChampionshipRepository : DomainRepository<Champion>, ITeamChampionshipRepository
{
    public TeamChampionshipRepository(DomainContext context) : base(context) { }

    public async Task<IEnumerable<Champion>> GetAll(int? teamId = null)
    {
        return teamId.HasValue
            ? await Items.Where(champion => champion.TeamId == teamId)
                         .ToListAsync()
            : await Items.ToListAsync();
    }
}
