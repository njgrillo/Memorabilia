using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Players;

public record GetPlayers(Franchise Franchise, Sport Sport) : IQuery<PlayersModel>
{
    public class Handler : QueryHandler<GetPlayers, PlayersModel>
    {
        private readonly IPersonTeamRepository _personTeamRepository;

        public Handler(IPersonTeamRepository personTeamRepository)
        {
            _personTeamRepository = personTeamRepository;
        }

        protected override async Task<PlayersModel> Handle(GetPlayers query)
        {
            return new PlayersModel(await _personTeamRepository.GetAll(query.Franchise.Id), query.Sport)
            {
                Franchise = query.Franchise
            };
        }
    }
}
