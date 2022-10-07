using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public class GetLeaderType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _leaderTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
