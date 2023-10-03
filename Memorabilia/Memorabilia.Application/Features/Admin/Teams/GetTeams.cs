namespace Memorabilia.Application.Features.Admin.Teams;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetTeams(int? FranchiseId = null, 
                       int? SportLeagueLevelId = null, 
                       int? SportId = null) 
    : IQuery<Entity.Team[]>
{
    public class Handler : QueryHandler<GetTeams, Entity.Team[]>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<Entity.Team[]> Handle(GetTeams query)
            => await _teamRepository.GetAll(query.FranchiseId,
                                            query.SportLeagueLevelId,
                                            query.SportId);
    }
}
