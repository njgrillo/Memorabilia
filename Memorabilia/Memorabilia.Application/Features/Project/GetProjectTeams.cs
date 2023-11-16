namespace Memorabilia.Application.Features.Project;

public record GetProjectTeams(int? SportId = null) : IQuery<Entity.Team[]>
{
    public class Handler(ITeamRepository teamRepository) 
        : QueryHandler<GetProjectTeams, Entity.Team[]>
    {
        protected override async Task<Entity.Team[]> Handle(GetProjectTeams query)
            => await teamRepository.GetAllCurrentTeams(sportId: query.SportId);
    }
}
