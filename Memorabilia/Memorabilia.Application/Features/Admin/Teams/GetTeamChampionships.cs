namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamChampionships(int TeamId) : IQuery<Entity.Champion[]>
{
    public class Handler : QueryHandler<GetTeamChampionships, Entity.Champion[]>
    {
        private readonly ITeamChampionshipRepository _teamChampionshipRepository;

        public Handler(ITeamChampionshipRepository teamChampionshipRepository)
        {
            _teamChampionshipRepository = teamChampionshipRepository;
        }

        protected override async Task<Entity.Champion[]> Handle(GetTeamChampionships query)
            => (await _teamChampionshipRepository.GetAll(query.TeamId))
                    .OrderBy(champion => champion.Year)
                    .ToArray();
    }
}
