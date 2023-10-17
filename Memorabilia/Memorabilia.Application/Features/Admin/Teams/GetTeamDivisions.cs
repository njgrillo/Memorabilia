namespace Memorabilia.Application.Features.Admin.Teams;

public record GetTeamDivisions(int TeamId) : IQuery<Entity.TeamDivision[]>
{
    public class Handler : QueryHandler<GetTeamDivisions, Entity.TeamDivision[]>
    {
        private readonly ITeamDivisionRepository _teamDivisionRepository;

        public Handler(ITeamDivisionRepository teamDivisionRepository)
        {
            _teamDivisionRepository = teamDivisionRepository;
        }

        protected override async Task<Entity.TeamDivision[]> Handle(GetTeamDivisions query)
            => (await _teamDivisionRepository.GetAll(query.TeamId))
                    .OrderBy(teamDivision => teamDivision.DivisionName)
                    .ThenBy(teamDivision => teamDivision.Team?.Name)
                    .ToArray();
    }
}
