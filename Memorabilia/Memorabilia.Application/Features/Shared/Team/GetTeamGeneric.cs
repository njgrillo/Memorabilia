namespace Memorabilia.Application.Features.Shared.Team;

public record GetTeamGeneric(int Id) : IQuery<Entity.Team>
{
    public class Handler : QueryHandler<GetTeamGeneric, Entity.Team>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<Entity.Team> Handle(GetTeamGeneric query)
        {
            return await _teamRepository.Get(query.Id);
        }
    }
}
