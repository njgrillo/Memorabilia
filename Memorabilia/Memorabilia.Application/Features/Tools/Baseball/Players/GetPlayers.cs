namespace Memorabilia.Application.Features.Tools.Baseball.Players;

public record GetPlayers(int FranchiseId) : IQuery<PlayersViewModel>
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
            return new PlayersViewModel(await _personTeamRepository.GetAll(query.FranchiseId))
            {
                FranchiseId = query.FranchiseId
            };
        }
    }
}
