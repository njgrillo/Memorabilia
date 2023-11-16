namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeams(int? FranchiseId = null, 
                       int? SportLeagueLevelId = null, 
                       int? SportId = null) 
    : IQuery<Entity.Team[]>
{
    public class Handler(ITeamRepository teamRepository) 
        : QueryHandler<GetTeams, Entity.Team[]>
    {
        protected override async Task<Entity.Team[]> Handle(GetTeams query)
            => await teamRepository.GetAll(query.FranchiseId,
                                            query.SportLeagueLevelId,
                                            query.SportId);
    }
}
