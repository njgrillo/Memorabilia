namespace Memorabilia.Application.Features.Shared.Team;

public record GetTeamGeneric(int Id) : IQuery<Domain.Entities.Team>
{
    public class Handler : QueryHandler<GetTeamGeneric, Domain.Entities.Team>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<Domain.Entities.Team> Handle(GetTeamGeneric query)
        {
            return await _teamRepository.Get(query.Id);
        }
    }
}
