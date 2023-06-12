namespace Memorabilia.Application.Features.Project;

public record GetProjectTeams(int? SportId = null) : IQuery<Entity.Team[]>
{
    public class Handler : QueryHandler<GetProjectTeams, Entity.Team[]>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<Entity.Team[]> Handle(GetProjectTeams query)
            => await _teamRepository.GetAllCurrentTeams(sportId: query.SportId);
    }
}
