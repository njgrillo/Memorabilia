namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeam(int Id) : IQuery<TeamViewModel>
{
    public class Handler : QueryHandler<GetTeam, TeamViewModel>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<TeamViewModel> Handle(GetTeam query)
        {
            return new TeamViewModel(await _teamRepository.Get(query.Id));
        }
    }
}
