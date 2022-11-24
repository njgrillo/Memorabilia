namespace Memorabilia.Application.Features.Admin.Teams;

public record GetDomainTeams(int? FranchiseId = null, int? SportLeagueLevelId = null, int? SportId = null) : IQuery<IEnumerable<Domain.Entities.Team>>
{
    public class Handler : QueryHandler<GetDomainTeams, IEnumerable<Domain.Entities.Team>>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<IEnumerable<Domain.Entities.Team>> Handle(GetDomainTeams query)
        {
            return await _teamRepository.GetAll(query.FranchiseId, query.SportLeagueLevelId, query.SportId);
        }
    }
}
