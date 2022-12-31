using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Players;

public record GetPlayers(Franchise Franchise, Sport Sport) : IQuery<PlayersViewModel>
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
            return new PlayersViewModel(await _personTeamRepository.GetAll(query.Franchise.Id), query.Sport)
            {
                Franchise = query.Franchise
            };
        }
    }
}
