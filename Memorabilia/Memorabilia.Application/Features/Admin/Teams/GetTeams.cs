namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeams(int? FranchiseId = null, int? SportLeagueLevelId = null) : IQuery<TeamsViewModel>
{
    public class Handler : QueryHandler<GetTeams, TeamsViewModel>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<TeamsViewModel> Handle(GetTeams query)
        {
            return new TeamsViewModel(await _teamRepository.GetAll(query.FranchiseId, query.SportLeagueLevelId));
        }
    }
}
