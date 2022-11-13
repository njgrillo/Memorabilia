namespace Memorabilia.Application.Features.Tools.Shared.Players;

public record GetPlayers(int FranchiseId, Domain.Constants.SportLeagueLevel SportLeagueLevel) : IQuery<PlayersViewModel>
{
    public class Handler : QueryHandler<GetPlayers, PlayersViewModel>
    {
        private readonly IPersonTeamRepository _personTeamRepository;

        public Handler(IPersonTeamRepository personTeamRepository)
        {
            _personTeamRepository = personTeamRepository;
        }

        protected override async Task<PlayersViewModel> Handle(GetPlayers query)
        {
            return new PlayersViewModel(await _personTeamRepository.GetAll(query.FranchiseId), query.SportLeagueLevel)
            {
                FranchiseId = query.FranchiseId
            };
        }
    }
}
