namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamDivisions(int TeamId) : IQuery<Entity.TeamDivision[]>
{
    public class Handler(ITeamDivisionRepository teamDivisionRepository) 
        : QueryHandler<GetTeamDivisions, Entity.TeamDivision[]>
    {
        protected override async Task<Entity.TeamDivision[]> Handle(GetTeamDivisions query)
            => (await teamDivisionRepository.GetAll(query.TeamId))
                    .OrderBy(teamDivision => teamDivision.DivisionName)
                    .ThenBy(teamDivision => teamDivision.Team?.Name)
                    .ToArray();
    }
}
