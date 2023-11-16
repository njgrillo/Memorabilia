namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeam(int Id) : IQuery<Entity.Team>
{
    public class Handler(ITeamRepository teamRepository) 
        : QueryHandler<GetTeam, Entity.Team>
    {
        protected override async Task<Entity.Team> Handle(GetTeam query)
            => await teamRepository.Get(query.Id);
    }
}
