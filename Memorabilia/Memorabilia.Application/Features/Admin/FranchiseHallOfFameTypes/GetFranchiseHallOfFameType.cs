using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public class GetFranchiseHallOfFameType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _franchiseHallOfFameTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
