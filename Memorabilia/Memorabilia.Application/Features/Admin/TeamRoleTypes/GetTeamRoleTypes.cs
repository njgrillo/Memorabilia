namespace Memorabilia.Application.Features.Admin.TeamRoleTypes
{
    public class GetTeamRoleTypes
    {
        public class Handler : QueryHandler<Query, TeamRoleTypesViewModel>
        {
            private readonly ITeamRoleTypeRepository _TeamRoleTypeRepository;

            public Handler(ITeamRoleTypeRepository TeamRoleTypeRepository)
            {
                _TeamRoleTypeRepository = TeamRoleTypeRepository;
            }

            protected override async Task<TeamRoleTypesViewModel> Handle(Query query)
            {
                return new TeamRoleTypesViewModel(await _TeamRoleTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<TeamRoleTypesViewModel> { }
    }
}
