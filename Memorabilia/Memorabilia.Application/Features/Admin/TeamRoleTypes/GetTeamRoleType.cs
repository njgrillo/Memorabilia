namespace Memorabilia.Application.Features.Admin.TeamRoleTypes
{
    public class GetTeamRoleType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly ITeamRoleTypeRepository _TeamRoleTypeRepository;

            public Handler(ITeamRoleTypeRepository TeamRoleTypeRepository)
            {
                _TeamRoleTypeRepository = TeamRoleTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _TeamRoleTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
