namespace Memorabilia.Application.Features.Tools.Shared.Players;

public record GetPlayers(Constant.Franchise Franchise, 
                         Constant.Sport Sport) 
    : IQuery<Entity.PersonTeam[]>
{
    public class Handler(IPersonTeamRepository personTeamRepository) 
        : QueryHandler<GetPlayers, Entity.PersonTeam[]>
    {
        protected override async Task<Entity.PersonTeam[]> Handle(GetPlayers query)
            => (await personTeamRepository.GetAll(query.Franchise.Id))
                    .ToArray();
    }
}
