namespace Memorabilia.Application.Features.Project;

public record GetProjectTeams(int? SportId = null) : IQuery<Domain.Entities.Team[]>
{
    public class Handler : QueryHandler<GetProjectTeams, Domain.Entities.Team[]>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<Domain.Entities.Team[]> Handle(GetProjectTeams query)
        {
            return await _teamRepository.GetAllCurrentTeams(sportId: query.SportId);
        }
    }
}
