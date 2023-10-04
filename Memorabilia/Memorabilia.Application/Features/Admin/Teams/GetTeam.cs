namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeam(int Id) : IQuery<Entity.Team>
{
    public class Handler : QueryHandler<GetTeam, Entity.Team>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<Entity.Team> Handle(GetTeam query)
            => await _teamRepository.Get(query.Id);
    }
}
