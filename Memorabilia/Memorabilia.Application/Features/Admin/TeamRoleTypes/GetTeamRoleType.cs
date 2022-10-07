using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public class GetTeamRoleType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<TeamRoleType> _TeamRoleTypeRepository;

        public Handler(IDomainRepository<TeamRoleType> TeamRoleTypeRepository)
        {
            _TeamRoleTypeRepository = TeamRoleTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _TeamRoleTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
