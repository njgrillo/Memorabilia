namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamChampionships(int TeamId) : IQuery<Entity.Champion[]>
{
    public class Handler(ITeamChampionshipRepository teamChampionshipRepository) 
        : QueryHandler<GetTeamChampionships, Entity.Champion[]>
    {
        protected override async Task<Entity.Champion[]> Handle(GetTeamChampionships query)
            => (await teamChampionshipRepository.GetAll(query.TeamId))
                    .OrderBy(champion => champion.Year)
                    .ToArray();
    }
}
