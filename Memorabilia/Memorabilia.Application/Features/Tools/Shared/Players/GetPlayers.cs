namespace Memorabilia.Application.Features.Tools.Shared.Players;

public record GetPlayers(Constant.Franchise Franchise, 
                         Constant.Sport Sport) 
    : IQuery<Entity.PersonTeam[]>
{
    public class Handler : QueryHandler<GetPlayers, Entity.PersonTeam[]>
    {
        private readonly IPersonTeamRepository _personTeamRepository;

        public Handler(IPersonTeamRepository personTeamRepository)
        {
            _personTeamRepository = personTeamRepository;
        }

        protected override async Task<Entity.PersonTeam[]> Handle(GetPlayers query)
            => (await _personTeamRepository.GetAll(query.Franchise.Id))
                    .ToArray();
    }
}
