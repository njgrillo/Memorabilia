namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamChampionships(int TeamId) : IQuery<IEnumerable<TeamChampionshipViewModel>>
{
    public class Handler : QueryHandler<GetTeamChampionships, IEnumerable<TeamChampionshipViewModel>>
    {
        private readonly ITeamChampionshipRepository _teamChampionshipRepository;

        public Handler(ITeamChampionshipRepository teamChampionshipRepository)
        {
            _teamChampionshipRepository = teamChampionshipRepository;
        }

        protected override async Task<IEnumerable<TeamChampionshipViewModel>> Handle(GetTeamChampionships query)
        {
            var teamChampionships = (await _teamChampionshipRepository.GetAll(query.TeamId)).OrderBy(champion => champion.Year);

            return teamChampionships.Select(teamChampionship => new TeamChampionshipViewModel(teamChampionship));
        }
    }
}
