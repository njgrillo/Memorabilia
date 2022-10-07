namespace Memorabilia.Application.Features.Admin.Teams;

public class GetTeam
{
    public class Handler : QueryHandler<Query, TeamViewModel>
    {
        private readonly ITeamRepository _teamRepository;

        public Handler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        protected override async Task<TeamViewModel> Handle(Query query)
        {
            return new TeamViewModel(await _teamRepository.Get(query.Id));
        }
    }

    public class Query : IQuery<TeamViewModel>
    {
        public Query(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
