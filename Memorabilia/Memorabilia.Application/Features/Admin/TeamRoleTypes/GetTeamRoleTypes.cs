using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public class GetTeamRoleTypes
{
    public class Handler : QueryHandler<Query, TeamRoleTypesViewModel>
    {
        private readonly IDomainRepository<TeamRoleType> _TeamRoleTypeRepository;

        public Handler(IDomainRepository<TeamRoleType> TeamRoleTypeRepository)
        {
            _TeamRoleTypeRepository = TeamRoleTypeRepository;
        }

        protected override async Task<TeamRoleTypesViewModel> Handle(Query query)
        {
            return new TeamRoleTypesViewModel(await _TeamRoleTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<TeamRoleTypesViewModel> { }
}
